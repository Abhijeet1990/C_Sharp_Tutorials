using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ForecastWizardApplication.Infrastructure
{
    public class GenerateXML
    {
        public void updateObject(ref SiteNode _siteNode, string[] levels, string name, int tag, string configuartion)
        {
            if (levels.Length > 0)
            {
                switch (levels.Length)
                {
                    case 1:
                        _siteNode._name = name;
                        _siteNode._id = tag;
                        break;
                    case 2:
                        _siteNode._site[Convert.ToInt32(levels[1])]._name = name;
                        _siteNode._site[Convert.ToInt32(levels[1])]._blockID = tag;
                        break;
                    case 3:
                        if (configuartion == "GasTurbine")
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._gasTurbineName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._gtId = tag;
                        }
                        else if (configuartion == "SteamTurbine")
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])]._steamTurbineName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])]._stId = tag;
                        }
                        break;
                    case 4:
                        if (configuartion == "HRSG")
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._hRSGTree._hrsgName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._hRSGTree._hrsgId = tag;
                        }
                        else if (configuartion == "CTGenerator")
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._cTGeneratorTree._ctGeneratorName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._gasTurbineTree[Convert.ToInt32(levels[2])]._cTGeneratorTree._genId = tag;
                        }
                        else if (configuartion == "STGenerator") // need to correct 
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])].sTGeneratorTreeSteam._stGeneratorName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])].sTGeneratorTreeSteam._stgenId = tag;
                        }
                        else if (configuartion == "Condenser")
                        {
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])]._condenserTree._CondenserName = name;
                            _siteNode._site[Convert.ToInt32(levels[1])]._steamTurbineTree[Convert.ToInt32(levels[2])]._condenserTree._condenId = tag;
                        }
                        break;
                }
            }
        }

        //SiteNode _siteNode = new SiteNode();
        public void Create(SiteNode _siteNode)
        {
            XmlWriter writer = XmlWriter.Create("C:\\ForecastWizardnew1.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Sites");
            writer.WriteStartElement("SiteId");
            writer.WriteString(_siteNode._id.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("SiteName");
            writer.WriteString(_siteNode._name);
            writer.WriteEndElement();

            writer.WriteStartElement("Longitude");
            writer.WriteString(_siteNode._longitude.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Latitude");
            writer.WriteString(_siteNode._latitude.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Elevation");
            writer.WriteString(_siteNode._elevation.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Interval");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxInterval));
            writer.WriteEndElement();

            writer.WriteStartElement("Duration");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxDuration));
            writer.WriteEndElement();

            writer.WriteStartElement("ArchiveInterval");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxArchiveInterval));
            writer.WriteEndElement();

            writer.WriteStartElement("ArchiveDuration");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxArchiveDuration));
            writer.WriteEndElement();

            writer.WriteStartElement("GridFrequency");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxGridFrequency));
            writer.WriteEndElement();

            writer.WriteStartElement("HeatRateUnits");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxHeatRateUnits));
            writer.WriteEndElement();

            writer.WriteStartElement("HeatRateCalculation");
            writer.WriteString(Convert.ToString(_siteNode._comboBoxHeatRateCalculation));
            writer.WriteEndElement();

            writer.WriteStartElement("TagList");
            writer.WriteStartElement("AmbientAir");
          
            writer.WriteStartElement("Pressure");
            writer.WriteStartElement("Tag");
            writer.WriteString("01AB02CP123.XQ01");
            writer.WriteEndElement();
            writer.WriteStartElement("Units");
            writer.WriteString("mbar");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("RelativeHumidity");
            writer.WriteStartElement("Tag");
            writer.WriteString("01ABC02CH123.XQ01");
            writer.WriteEndElement();
            writer.WriteStartElement("Units");
            writer.WriteString("%");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("Temperature");
            writer.WriteStartElement("Tag");
            writer.WriteString("01ABC02CT123.XQ01");
            writer.WriteEndElement();
            writer.WriteStartElement("Units");
            writer.WriteString("°C");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Blocks");

            foreach (BlockTree _blockTree_ in _siteNode._site)
            {
                writer.WriteStartElement("Block");
                writer.WriteStartElement("BlockId");
                writer.WriteString(Convert.ToString(_blockTree_._blockID));
                writer.WriteEndElement();
                writer.WriteStartElement("BlockName");
                writer.WriteString(Convert.ToString(_blockTree_._name));
                writer.WriteEndElement();
                writer.WriteStartElement("BlockConfiguration");
                writer.WriteString(Convert.ToString(_blockTree_._typeConfig));
                writer.WriteEndElement();
                writer.WriteStartElement("GasTurbineType");
                writer.WriteString(Convert.ToString(_blockTree_._gasTurbineType));
                writer.WriteEndElement();
                writer.WriteStartElement("BlockEnahancement");
                //adding enhancement
                //1st enhancement
                writer.WriteStartElement("Anti-lcing");
                writer.WriteStartElement("Alias");
                writer.WriteString("AI");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx1);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //2nd enhancement
                writer.WriteStartElement("InletAirHeating");
                writer.WriteStartElement("Alias");
                writer.WriteString("IAH");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx2);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //3rd enhancement
                writer.WriteStartElement("CombustionAuto-Tuning");
                writer.WriteStartElement("Alias");
                writer.WriteString("CAT");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx3);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //4th enhancement
                writer.WriteStartElement("PeakFiring");
                writer.WriteStartElement("Alias");
                writer.WriteString("PF");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx4);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //5th enhancement
                writer.WriteStartElement("DuctBurners");
                writer.WriteStartElement("Alias");
                writer.WriteString("DB");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx5);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //6th enhancement
                writer.WriteStartElement("SteamPowerAugmentation");
                writer.WriteStartElement("Alias");
                writer.WriteString("SI(NODB)");
                writer.WriteEndElement();
                writer.WriteStartElement("Fitted");
                writer.WriteString(_blockTree_.chkbx6);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding---
                string cBox1, cBox2, cBox3, cBox4, cBox5, cBox6, cBox7;
                if (_blockTree_.chkbx1 == "Yes")
                    cBox1 = "Schedule";
                else
                    cBox1 = "NotSchedule";
                if (_blockTree_.chkbx2 == "Yes")
                    cBox2 = "Schedule";
                else
                    cBox2 = "NotSchedule";
                if (_blockTree_.chkbx3 == "Yes")
                    cBox3 = "Schedule";
                else
                    cBox3 = "NotSchedule";
                if (_blockTree_.chkbx4 == "Yes")
                    cBox4 = "Schedule";
                else
                    cBox4 = "NotSchedule";
                if (_blockTree_.chkbx5 == "Yes")
                    cBox5 = "Schedule";
                else
                    cBox5 = "NotSchedule";
                if (_blockTree_.chkbx6 == "Yes")
                    cBox6 = "Schedule";
                else
                    cBox6 = "NotSchedule";
                if (_blockTree_.chkbx7 == "Yes")
                    cBox7 = "Schedule";
                else
                    cBox7 = "NotSchedule";

                writer.WriteStartElement("BaseLoadandHeatRateForecast");
                writer.WriteStartElement("Enhancements");

                //adding AntiLcing
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("AntiLcing");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox1);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding InletAirHeating
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("InletAirHeating");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox2);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding Combuston Auto-Tuning
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("CombustonAutoTuning");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox3);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding Peak Firing
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("PeakFiring");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox4);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding Duck Burners
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("DuckBurners");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox5);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding Steam Power Augmentation
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("SteamPowerAugmentation");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox6);
                writer.WriteEndElement();
                writer.WriteEndElement();

                //adding Only with Duck Burners
                writer.WriteStartElement("Enhancement");
                writer.WriteStartElement("Identity");
                writer.WriteString("OnlywithDuckBurners");
                writer.WriteEndElement();
                writer.WriteStartElement("Option");
                writer.WriteString(cBox7);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("LongName");
                writer.WriteString(BlockData.lname ?? "");
                writer.WriteEndElement();

                writer.WriteStartElement("ShortName");
                writer.WriteString(BlockData.sname ?? "");

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                foreach (GasTurbineTree _gasTurbine_ in _blockTree_._gasTurbineTree)
                {
                    writer.WriteStartElement("GasTurbine");

                    writer.WriteStartElement("GasTurbineId");
                    writer.WriteString(Convert.ToString(_gasTurbine_._gtId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("GasTurbineName");
                    writer.WriteString(_gasTurbine_._gasTurbineName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("CTGenerator");
                    writer.WriteStartElement("CTGeneratorId");
                    writer.WriteString(Convert.ToString(_gasTurbine_._cTGeneratorTree._genId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("CTGeneratorName");
                    writer.WriteString(_gasTurbine_._cTGeneratorTree._ctGeneratorName);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("HRSG");
                    writer.WriteStartElement("HRSGId");
                    writer.WriteString(Convert.ToString(_gasTurbine_._hRSGTree._hrsgId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("HRSGName");
                    writer.WriteString(_gasTurbine_._hRSGTree._hrsgName);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                foreach (SteamTurbineTree _steamTurbine_ in _blockTree_._steamTurbineTree)
                {
                    writer.WriteStartElement("SteamTurbine");

                    writer.WriteStartElement("SteamTurbineId");
                    writer.WriteString(Convert.ToString(_steamTurbine_._stId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("SteamTurbineName");
                    writer.WriteString(_steamTurbine_._steamTurbineName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("STGenerator");
                    writer.WriteStartElement("STGeneratorId");
                    writer.WriteString(Convert.ToString(_steamTurbine_.sTGeneratorTreeSteam._stgenId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("STGeneratorName");
                    writer.WriteString(_steamTurbine_.sTGeneratorTreeSteam._stGeneratorName);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("Condenser");
                    writer.WriteStartElement("CondenserId");
                    writer.WriteString(Convert.ToString(_steamTurbine_._condenserTree._condenId));
                    writer.WriteEndElement();
                    writer.WriteStartElement("CondenserName");
                    writer.WriteString(_steamTurbine_._condenserTree._CondenserName);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                }
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
