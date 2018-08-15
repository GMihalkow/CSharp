using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class DraftManager
{
    private string currentMode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        currentMode = Modes.Full.ToString() + " Mode";
        totalMinedOre = 0;
        totalStoredEnergy = 0;
        harvesters = new List<Harvester>();
        providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string harvesterType = arguments[0];
        string harvesterID = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        try
        {
            Harvester harvester = new HammerHarvester(harvesterID, oreOutput, energyRequirement);

            switch (harvesterType)
            {
                case "Sonic":
                    {
                        int sonicFactor = int.Parse(arguments[4]);
                        harvester = new SonicHarvester(harvesterID, oreOutput, energyRequirement, sonicFactor);
                        harvesters.Add(harvester);
                        return $"Successfully registered Sonic Harvester - {harvesterID}";

                    }
                    break;
                case "Hammer":
                    {
                        harvesters.Add(harvester);
                        return $"Successfully registered Hammer Harvester - {harvesterID}";

                    }
                    break;
                default:
                    return string.Empty;
            }

        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

    }

    public string RegisterProvider(List<string> arguments)
    {
        string providerType = arguments[0];
        string providerID = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        Provider provider;
        try
        {
            switch (providerType)
            {
                case "Solar":
                    {
                        provider = new SolarProvider(providerID, energyOutput);
                        providers.Add(provider);
                        return $"Successfully registered Solar Provider - {providerID}";

                    }
                    break;
                case "Pressure":
                    {
                        provider = new PressureProvider(providerID, energyOutput);
                        providers.Add(provider);
                        return $"Successfully registered Pressure Provider - {providerID}";

                    }
                    break;
                default:
                    return string.Empty;
            }

        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double summedEnergyOutput =
            providers
            .Sum(w => w.EnergyOutput);
        totalStoredEnergy += summedEnergyOutput;

        double summedEnergyRequirement =
            harvesters
            .Sum(w => w.EnergyRequirement);

        bool IsEnergyEnough = summedEnergyRequirement > totalStoredEnergy;
        if (IsEnergyEnough == true)
        {
            return $"A day has passed." + Environment.NewLine +
                $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
                $"Plumbus Ore Mined: 0";
        }
        else
        {
            double summedOurOutput;
            if (currentMode == "Full Mode")
            {
                summedOurOutput =
                    harvesters
                    .Sum(w => w.OreOutput);

                totalStoredEnergy -= summedEnergyRequirement;
                totalMinedOre += summedOurOutput;
                return $"A day has passed." + Environment.NewLine +
                    $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
                    $"Plumbus Ore Mined: {summedOurOutput}";

            }
            else if (currentMode == "Half Mode")
            {
                summedOurOutput =
                    harvesters
                    .Sum(w => w.OreOutput);

                totalStoredEnergy -= summedEnergyRequirement * 0.6;
                totalMinedOre += summedOurOutput * 0.5;
                return $"A day has passed." + Environment.NewLine +
                    $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
                    $"Plumbus Ore Mined: {summedOurOutput * 0.5}";
            }
            else if (currentMode == "Energy Mode")
            {
                return $"A day has passed." + Environment.NewLine +
                    $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
                    $"Plumbus Ore Mined: 0";
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];

        this.currentMode = newMode + " Mode";

        return $"Successfully changed working mode to {newMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        bool IsProviderThere = providers.Any(p => p.ID == id);
        bool IsHarvesterThere = harvesters.Any(h => h.ID == id);

        //Provider format:
        //“{type} Provider – {id}
        //Energy Output: { energyOutput}”

        //Harvester format:
        //“{type} Harvester – {id}
        //Ore Output: { oreOutput}
        //Energy Requirement: { energyRequired}”

        if (IsProviderThere == true)
        {
            string providerType = string.Empty;
            Provider provider = providers.First(p => p.ID == id);
            if (provider is SolarProvider)
            {
                providerType = "Solar";
            }
            else if (provider is PressureProvider)
            {
                providerType = "Pressure";
            }

            return ($"{providerType} Provider - {provider.ID}" + Environment.NewLine +
                $"Energy Output: {provider.EnergyOutput}");
        }
        else if (IsHarvesterThere == true)
        {
            string harvesterType = string.Empty;
            Harvester harvester = harvesters.First(h => h.ID == id);

            if (harvester is HammerHarvester)
            {
                harvesterType = "Hammer";
            }
            else if (harvester is SonicHarvester)
            {
                harvesterType = "Sonic";
            }

            return ($"{harvesterType} Harvester - {harvester.ID}" + Environment.NewLine +
                $"Ore Output: {harvester.OreOutput}" + Environment.NewLine 
                + $"Energy Requirement: {harvester.EnergyRequirement}");
        }
        else
        {
            return $"No element found with id - {id}";
        }

    }

    public string ShutDown()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Format($"System Shutdown" + Environment.NewLine + $"Total Energy Stored: {totalStoredEnergy}" + Environment.NewLine + $"Total Mined Plumbus Ore: {totalMinedOre}"));

        return stringBuilder.ToString().Trim();
    }
}