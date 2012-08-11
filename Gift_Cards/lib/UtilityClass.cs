using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Configuration;
using System.ServiceModel;
using Gift_Cards.VoyageService;
using System.Text;

/// <summary>
/// This class privides methods that are invoqued for the project forms in orther to 
/// not repeat code and have more control of the functionality of the project.
/// </summary>
public class UtilityClass
{
    /// <summary>
    /// String that contains the path to access the TYPE.TXT file.
    /// </summary>
    public static string typeXML = ConfigurationSettings.AppSettings["TypeXMLPath"];
    /// <summary>
    /// String that contains the path to access the GIFTCDS.TXT file.
    /// </summary>
    public static string giftcardFile = ConfigurationSettings.AppSettings["GiftcardFilePath"];
    
    /// <summary>
    /// String that contains the path to create AMENITIES.xml 
    /// </summary>
    public static string amenitiesXML = ConfigurationSettings.AppSettings["AmenitiesXMLPath"];
    /// <summary>
    /// path to get the shipname
    /// </summary>
    public static string shipName = ConfigurationSettings.AppSettings["shipName"];
    /// <summary>
    /// path to get the shipcode immediately
    /// </summary>
    public static string shipCode = ConfigurationSettings.AppSettings["shipCode"];
    /// <summary>
    /// path to create or write the LOG file
    /// </summary>
    public static string logPath = ConfigurationSettings.AppSettings["logPath"];

    public UtilityClass() { }

    /// <summary>
    /// This method read the GIFTCDS.TXT file and fill List<GiftCard>, List<Amenity> depends on which form it it call.
    /// </summary>
    /// <param name="clist"> List of GiftCard objects </param>
    /// <param name="alist"> List of Amenity objects</param>
    public static void getDataCards(List<GiftCard> clist)
    {
         try
        {
            string[] files = Directory.GetFiles("C:\\", "*.TXT");
            var filePath = GetFilePath(giftcardFile);
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
               
                string line;
                //read file till EOF
                while ((line = sr.ReadLine()) != null)
                {
                    GiftCard currentCard = new GiftCard();

                    //put all tokens into an array to have better access to them individually
                    string[] words = line.Split('|');
                    
                    //assign to giftcard the properties from file that was read
                    currentCard.Voyage = words[0] != " " ? words[0].Trim().ToString() : " ";
                    currentCard.Saildate = words[1] != " " ? FixDate(words[1].Trim().ToString()) : " ";
                    currentCard.Deliverydate = words[2] != " " ? FixDate(words[2].Trim().ToString()) : " ";
                    currentCard.Amenity = words[3] != " " ? words[3].Trim().ToString() : " ";
                    // this is because if Qty is text then the sort on AllGiftCards dont work correct.
                    int tmpQty = 0;
                    if (words[4] != null) { int.TryParse(words[4].ToString(), out tmpQty); } currentCard.Qty = tmpQty;
                    currentCard.Compliments = words[5] != " " ? words[5].Trim().ToString() : " ";
                    currentCard.Message = words[6] != " " ? words[6].Trim().ToString() : " ";
                    currentCard.Cabin = words[7] != " " ? words[7].Trim().ToString() : " ";
                    currentCard.firstPaxFirst = words[8] != " " ? words[8].Trim().ToString() : " ";
                    currentCard.firstPaxLast = words[9] != " " ? words[9].Trim().ToString() : " ";
                    currentCard.secndPaxFirst = words[10] != " " ? words[10].Trim().ToString() : " ";
                    currentCard.secndPaxLast = words[11] != " " ? words[11].Trim().ToString() : " ";
                    currentCard.thirdPaxFirst = words[12] != " " ? words[12].Trim().ToString() : " ";
                    currentCard.thirdPaxLast = words[13] != " " ? words[13].Trim().ToString() : " ";
                    currentCard.fourthPaxFirst = words[14] != " " ? words[14].Trim().ToString() : " ";
                    currentCard.fourthPaxLast = words[15] != " " ? words[15].Trim().ToString() : " ";
                    currentCard.Ship = words[16] != " " ? words[16].Trim().ToString() : " ";
                    currentCard.Type = words[17] != " " ? words[17].Trim().ToString() : " ";
                    currentCard.DeliveryType = words[18] != " " ? words[18].Trim().ToString() : " ";
                    currentCard.DRoom = words[19] != " " ? words[19].Trim().ToString() : " ";
                    currentCard.Seating = words[20] != " " ? words[20].Trim().ToString() : " ";
                    currentCard.Table = words[21] != " " ? words[21].Trim().ToString() : " ";

                    // Add the new card to the list
                    clist.Add(currentCard);
                   
                }// end while

                // close the file
                sr.Close();

            }//end if
            else
            {
                throw new FileNotFoundException("The file " + giftcardFile + " could not be found");
            }//end else

        }//end try
         catch (FileNotFoundException ex) { ReportLog(ex.Message); }//end catch
         catch (Exception ex) { ReportLog(ex.Message); }//end catch

    }// end getDataCards

 
    /// <summary>
    /// This method returns a card object with a the same cabin number if not web server used
    /// </summary>
    /// <param name="list"> List of GiftCard objects</param>
    /// <param name="cabine"> a cabin number to find in the list</param>
    /// <returns></returns>
    public static GiftCard getCabine(List<GiftCard> list, string cabine)
    {
        foreach (GiftCard card in list)
            if (card.Cabin.Equals(cabine))
                return card;
        return null;
    }// end  getCabine    

    /// <summary>
    /// This method overrides the GIFTCDS.TXT file. 
    /// </summary>    
    /// <param name="list">List of GiftCards objects</param>
    public static void overrideGiftCardFile(List<GiftCard> list)
    {
        var filePath = GetFilePath(giftcardFile);
        if (File.Exists(filePath))
            File.Delete(filePath);

        StreamWriter aw = File.CreateText(filePath);
        foreach (GiftCard item in list)
            aw.WriteLine(item.toStringToFile());
        aw.Close();
        aw.Dispose();
    }// end overrideGiftCardFile

    /// <summary>
    /// This method serialize a List of Amenities to XML file
    /// </summary>
    /// <param name="list"> list of GiftCards</param>
    public static void AmenitySerializeToXML(List<Amenity> list)
    {
        var filePath = GetFilePath(amenitiesXML);
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Amenity>));
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }
        catch (Exception ex) { ReportLog(ex.Message); }
    }// end SerializeToXML

    /// <summary>
    /// This method read an XML document back into our Gift Card list - deserialization.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<Amenity> AmenityDeserializeFromXML()
    {
        List<Amenity> amenity = new List<Amenity>();
        try
        {
            var filePath = GetFilePath(amenitiesXML);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Amenity>));
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                amenity = (List<Amenity>)deserializer.Deserialize(textReader);
                textReader.Close();
                return amenity;
            }
        }
        catch (Exception ex) { ReportLog(ex.Message); }
        return amenity;
    }// end DeserializeFromXML

    /// <summary>
    /// This get the root to the file
    /// </summary>
    /// <returns></returns>
    static string GetRootPath()
    {
        return System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "").Replace("\\bin", "");
    }// end GetRootPath

    /// <summary>
    /// this function get the path
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetFilePath(string fileName)
    {
        return string.Format(@"{0}\data\{1}", GetRootPath(), fileName);
       
    }// end GetFilePath

    /// <summary>
    /// This method serialize a List of Type to XML file
    /// </summary>
    /// <param name="list"> list of Type</param>
    public static void TypeSerializeToXML(List<Type> list)
    {
        var filePath = GetFilePath(typeXML);
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Type>));
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }
        catch (Exception ex) { ReportLog(ex.Message); }
    }// end SerializeToXML

    /// <summary>
    /// This method read an XML document back into our Gift Card list - deserialization.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<Type> TypeDeserializeFromXML()
    {
        List<Type> type = new List<Type>();
        try
        {
            var filePath = GetFilePath(typeXML);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Type>));
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                type = (List<Type>)deserializer.Deserialize(textReader);
                textReader.Close();
                return type;
            }
        }
        catch (Exception ex) { ReportLog(ex.Message); }
        return type;
    }// end DeserializeFromXML 

    /// <summary>
    /// Returns a List<GuestService.GuestView> with specific stateroom number
    /// </summary>
    /// <param name="stateroom"></param>
    /// <returns></returns>
    public static List<Gift_Cards.GuestService.GuestView> TryGetGuestInfo(int stateroom, Label lbl)
    {
        using (var connection = new Gift_Cards.GuestService.GuestServicePortTypeClient())
        {   //if connection was not created
            if (connection.State == CommunicationState.Faulted) { ReportLog("Connection Failed"); lbl.Text = "Connection Failed!"; }
            else
            {
                try
                {
                    var criteria = new Gift_Cards.GuestService.GuestSearchCriteria();
                    criteria.stateroomNumber = stateroom;// = stateroom;                
                    var x = connection.getGuestsForSailing(criteria).ToList();
                    var stroom = x.FindAll((st) => st.stateroomNumber.Equals(Convert.ToString(criteria.stateroomNumber)) && st.shipCode.Equals(shipCode));
                    return stroom.Count == 0 ? null : stroom.ToList();
                }// end try
                //Communication exception 
                catch (CommunicationException exp) { ReportLog(exp.Message); lbl.Text = "Communication issue try again later!"; return null; }
                //Time out exception
                catch (TimeoutException exp) { ReportLog(exp.Message); lbl.Text = "Connection Time Out!"; return null; }
                //Catch Exception
                catch (Exception exp) { ReportLog(exp.Message); lbl.Text = "Contact your Administrator!"; return null; }
            }//end else

            return null;
        }//end using

    }// end TryGetGuestInfo

    public static Gift_Cards.VoyageService.VoyageView TryGetShipInfo(Label lbl)
    {
        using (var connection = new Gift_Cards.VoyageService.VoyageServicePortTypeClient())
        {   //if connection was not created
            if (connection.State == CommunicationState.Faulted) { ReportLog("Connection Failed"); lbl.Text = "Connection Failed!"; }
            else
            {
                try
                {
                    var x = connection.getCurrentVoyage(shipCode);
                    return x;
                }// end try
                //Communication exception 
                catch (CommunicationException exp) { ReportLog(exp.Message); lbl.Text = "Communication issue try again later!"; return null; }
                //Time out exception
                catch (TimeoutException exp) { ReportLog(exp.Message); lbl.Text = "Connection Time Out!"; return null; }
                //Catch Exception
                catch (Exception exp) { ReportLog(exp.Message); lbl.Text = "Contact your Administrator!"; return null; }
            }//end else

            return null;
        }//end using       

    }// end TryGetShipInfo()

    /// <summary>
    /// function creates or writes to an existing log any exception that were catched
    /// </summary>
    /// <param name="message"></param>
    public static void ReportLog(String message)
    {
        var filePath = GetFilePath(logPath);
        if (System.IO.File.Exists(filePath + DateTime.Now.ToString("MM/dd/yyyy") + "err.log"))
        {
            using (FileStream fs = new FileStream(filePath + DateTime.Now.ToString("yyyy-MM-dd") + "err.log", FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(message);
                sw.Close();
            }//end using
        }//end if
        else
        {
            using (FileStream fs = new FileStream(filePath + DateTime.Now.ToString("yyyy-MM-dd") + "err.log", FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(message);
                sw.Close();
            }//end using
        }//end else
    }//end ReportLog

    // ******* Helpers to validate imput values.
    /// <summary>
    /// This functions checks if text is empty or invalid string 
    /// </summary>
    /// <returns></returns>
    public static Boolean isValidText(TextBox txt, Label lab, string str1, string str2)
    {
        if (string.IsNullOrEmpty(txt.Text.Trim())) { lab.Text = str1; return false; }

        // is Alpha numeric
        if (!Regex.IsMatch(txt.Text.Trim(), "^[a-zA-Z0-9' () @ !]+$")) { lab.Text = str2; return false; }

        lab.Text = "";
        return true;
    }// end isValidText

    /// <summary>
    /// This method cheks if the user select a value on a DropDownList
    /// </summary>    
    public static Boolean isValidText(DropDownList txt, Label lab, string str1)
    {
        if (txt.SelectedValue.Equals("--- select item ---")) { lab.Text = str1; return false; }
        lab.Text = "";
        return true;
    }// end inputValidation

    /// <summary>
    /// This function check if the date is empty or in wrong format
    /// </summary>    
    public static Boolean isValidDate(TextBox txt, Label lab, string str1, string str2)
    {
        // check for empty
        if (string.IsNullOrEmpty(txt.Text.Trim())) { lab.Text = str1; return false; }

        // check the date format (MM/DD/YYYY)
        if (!Regex.IsMatch(txt.Text.Trim(), "^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)")) { lab.Text = str2; return false; }

        lab.Text = "";
        return true;
    }// end isValidDate

    /// <summary>
    /// this method check if the input is a valid integer number 
    /// </summary>
    public static Boolean isValidInt(TextBox txt, Label lab, string str1, string str2)
    {
        if (string.IsNullOrEmpty(txt.Text.Trim())) { lab.Text = str1; return false; }

        int iOut;
        if (!int.TryParse(txt.Text.Trim(), out iOut)) { lab.Text = str2; return false; }
        if (int.Parse(txt.Text.Trim()) < 1) { lab.Text = str2; return false; }
        lab.Text = "";
        return true;
    }// end isValidInt

    /// <summary>
    /// This function checks if there is a chronological mistake between to date
    /// </summary>
    /// <returns> boolean </returns>
    public static Boolean isChronologicalDate(TextBox date1, TextBox date2, Label lab, string str)
    {
        string d1 = FixDateToFile(date1.Text.ToString());
        string d2 = FixDateToFile(date2.Text.ToString());
        if (d1.CompareTo(d2) > 0)
        {  
            lab.Text = str;
            return false;
        }        
        else        
        {
            return true;
        }
    }// end validDate

    /// <summary>
    /// This method fix the date format coming in the file from (yyyymmdd) to (mm/dd/yyyy) called on
    /// getDataCards when reading the file to print dates in the reports
    /// </summary>
    /// <param name="strbreak">data yyyymmdd</param>
    /// <returns>mm/dd/yyyy</returns>
    public static string FixDate(string strbreak)
    {
        return strbreak.Substring(4, 2) + "/" + strbreak.Substring(6, 2) + "/" + strbreak.Substring(0, 4);
    }// end FixDate

    /// <summary>
    /// This funtion sets the date to the file format called on GiftCard.toStringToFile() to write the file
    /// in the farmat that dates are coming
    /// </summary>
    /// <param name="strbreak">mm/dd/yyyy</param>
    /// <returns>yyyymmdd</returns>
    public static string FixDateToFile(string strbreak)
    {
        return strbreak.Substring(6, 4) + "" + strbreak.Substring(0, 2) + "" + strbreak.Substring(3, 2);
    }// end FixDate

    
}// end UtilityClass



