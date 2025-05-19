using Naninovel;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private static Map Instance;
    private IScriptPlayer player;

    [SerializeField]
    private LocationParam[] Locations;

    private Dictionary<string, LocationParam> LocationsDict = new Dictionary<string, LocationParam>();

    private async void Awake()
    {
        Instance = this;

        if (!Engine.Initialized)
            await RuntimeInitializer.InitializeAsync();

        player = Engine.GetService<IScriptPlayer>();

        foreach (var Location in Locations)
            LocationsDict.Add(Location.Id, Location);
    }

    private async void LoadLocation(string ID)
    {
        UIManager.SetInactiveUI("Map");
        await player.PreloadAndPlayAsync(ID);
    }

    private void ChangeAvailibility(string Id, bool Availible)
    {
        if (!LocationsDict.ContainsKey(Id)) throw new System.Exception($"No location with {Id} found!");

        LocationsDict[Id].ChangeAvailible(Availible);
    }

    public static void ChangeLocationAvailibility(string LocationId, bool Availible) => Instance.ChangeAvailibility(LocationId, Availible);
    public static void GoToLocation(string LocationId) => Instance.LoadLocation(LocationId);
}
