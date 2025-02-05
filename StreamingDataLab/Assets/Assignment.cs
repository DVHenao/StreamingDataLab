
/*
This RPG data streaming assignment was created by Fernando Restituto.
Pixel RPG characters created by Sean Browning.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

#region Assignment Instructions

/*  Hello!  Welcome to your first lab :)
Wax on, wax off.
    The development of saving and loading systems shares much in common with that of networked gameplay development.  
    Both involve developing around data which is packaged and passed into (or gotten from) a stream.  
    Thus, prior to attacking the problems of development for networked games, you will strengthen your abilities to develop solutions using the easier to work with HD saving/loading frameworks.
    Try to understand not just the framework tools, but also, 
    seek to familiarize yourself with how we are able to break data down, pass it into a stream and then rebuild it from another stream.
Lab Part 1
    Begin by exploring the UI elements that you are presented with upon hitting play.
    You can roll a new party, view party stats and hit a save and load button, both of which do nothing.
    You are challenged to create the functions that will save and load the party data which is being displayed on screen for you.
    Below, a SavePartyButtonPressed and a LoadPartyButtonPressed function are provided for you.
    Both are being called by the internal systems when the respective button is hit.
    You must code the save/load functionality.
    Access to Party Character data is provided via demo usage in the save and load functions.
    The PartyCharacter class members are defined as follows.  */

public partial class PartyCharacter
{
    public int classID;

    public int health;
    public int mana;

    public int strength;
    public int agility;
    public int wisdom;

    public LinkedList<int> equipment;

}


/*
    Access to the on screen party data can be achieved via …..
    Once you have loaded party data from the HD, you can have it loaded on screen via …...
    These are the stream reader/writer that I want you to use.
    https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter
    https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader
    Alright, that’s all you need to get started on the first part of this assignment, here are your functions, good luck and journey well!
*/


#endregion


#region Assignment Part 1
static public class AssignmentPart1
{

    static public void SavePartyButtonPressed1()
    {
        string equipData = "";

        DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\Temp").GetDirectories();


        using (StreamWriter sw = new StreamWriter("c:/Temp/CDriveDirs.txt"))
        {
            foreach (PartyCharacter pc in GameContent.partyCharacters)
            {

                foreach (int equipID in pc.equipment)
                {
                    //sw.WriteLine(equipID);

                    equipData = equipData + equipID.ToString();
                    equipData = equipData + ",";
                }
                equipData.Remove(equipData.Length - 1);

                string charData = pc.classID.ToString() + "," + pc.health.ToString() + "," + pc.mana.ToString() + "," + pc.strength.ToString()
                    + "," + pc.agility.ToString() + "," + pc.wisdom.ToString() + "," + equipData + "999";
                //sw.WriteLine(pc.classID);
                //sw.WriteLine(pc.health);
                //sw.WriteLine(pc.mana);
                //sw.WriteLine(pc.strength);
                //sw.WriteLine(pc.agility);
                //sw.WriteLine(pc.wisdom);
                //foreach (int equipID in pc.equipment)
                //{
                //    sw.WriteLine(equipID);
                //}
                sw.WriteLine(charData);
                equipData = "";
            }
        }

        foreach (PartyCharacter pc in GameContent.partyCharacters)
        {
            Debug.Log("PC class id == " + pc.classID);
        }
    }

    static public void LoadPartyButtonPressed1()
    {

        GameContent.partyCharacters.Clear();


        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("c:/Temp/CDriveDirs.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                for (int i = 0; i < 4; i++)
                {
                    string temp = sr.Peek().ToString();
                    Debug.Log("THIS IS TEMP" + temp);

                    if (temp != "")
                        // PLAY WITH THIS TO GET THE RIGHT AMOUNT OF CHARACTERS ACCORDING TO SAVE FILE
                        GameContent.partyCharacters.AddLast(new PartyCharacter());
                }

                foreach (PartyCharacter pc in GameContent.partyCharacters)
                {
                    string loadCharData = sr.ReadLine();

                    Debug.Log(loadCharData);

                    string[] broken_str = loadCharData.Split(',');

                    pc.classID = int.Parse(broken_str[0]);
                    pc.health = int.Parse(broken_str[1]);
                    pc.mana = int.Parse(broken_str[2]);
                    pc.strength = int.Parse(broken_str[3]);
                    pc.agility = int.Parse(broken_str[4]);
                    pc.wisdom = int.Parse(broken_str[5]);

                    pc.equipment.Clear();

                    if (broken_str[6] != "999")
                    {
                        Debug.Log("6" + int.Parse(broken_str[6]));
                        pc.equipment.AddLast(int.Parse(broken_str[6]));
                    }

                    if (broken_str[7] != "999")
                    {
                        Debug.Log("7" + int.Parse(broken_str[7]));
                        pc.equipment.AddLast(int.Parse(broken_str[7]));
                    }

                    if (broken_str[8] != "999")
                    {
                        Debug.Log("8" + int.Parse(broken_str[8]));
                        pc.equipment.AddLast(int.Parse(broken_str[8]));
                    }

                    if (broken_str[9] != "999")
                    {
                        Debug.Log("9" + int.Parse(broken_str[9]));
                        pc.equipment.AddLast(int.Parse(broken_str[9]));
                    }

                    for (int i = 0; i < broken_str.Length; i++)
                    {
                        broken_str[i] = "";
                    }







                    //pc.classID = int.Parse(sr.ReadLine());
                    //pc.health = int.Parse(sr.ReadLine());
                    //pc.mana = int.Parse(sr.ReadLine());
                    //pc.strength = int.Parse(sr.ReadLine());
                    //pc.agility = int.Parse(sr.ReadLine());
                    //pc.wisdom = int.Parse(sr.ReadLine());


                }

            }
        }

        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }



        GameContent.RefreshUI();

    }

}


#endregion


#region Assignment Part 2

//  Before Proceeding!
//  To inform the internal systems that you are proceeding onto the second part of this assignment,
//  change the below value of AssignmentConfiguration.PartOfAssignmentInDevelopment from 1 to 2.
//  This will enable the needed UI/function calls for your to proceed with your assignment.
static public class AssignmentConfiguration
{
    public const int PartOfAssignmentThatIsInDevelopment = 2;
}

/*
In this part of the assignment you are challenged to expand on the functionality that you have already created.  
    You are being challenged to save, load and manage multiple parties.
    You are being challenged to identify each party via a string name (a member of the Party class).
To aid you in this challenge, the UI has been altered.  
    The load button has been replaced with a drop down list.  
    When this load party drop down list is changed, LoadPartyDropDownChanged(string selectedName) will be called.  
    When this drop down is created, it will be populated with the return value of GetListOfPartyNames().
    GameStart() is called when the program starts.
    For quality of life, a new SavePartyButtonPressed() has been provided to you below.
    An new/delete button has been added, you will also find below NewPartyButtonPressed() and DeletePartyButtonPressed()
Again, you are being challenged to develop the ability to save and load multiple parties.
    This challenge is different from the previous.
    In the above challenge, what you had to develop was much more directly named.
    With this challenge however, there is a much more predicate process required.
    Let me ask you,
        What do you need to program to produce the saving, loading and management of multiple parties?
        What are the variables that you will need to declare?
        What are the things that you will need to do?  
    So much of development is just breaking problems down into smaller parts.
    Take the time to name each part of what you will create and then, do it.
Good luck, journey well.
*/

static public class AssignmentPart2
{

    static public void GameStart()
    {

        GameContent.RefreshUI();

    }

    static public List<string> GetListOfPartyNames(List<string> SaveFileName)
    {



        return SaveFileName;
    }

    static public void LoadPartyDropDownChanged(string selectedName)
    {
        GameContent.RefreshUI();
        LoadPartyButtonPressed2(selectedName);
    }

    static public void SavePartyButtonPressed()
    {
        GameContent.RefreshUI();
    }

    static public void NewPartyButtonPressed()
    {

    }

    static public void DeletePartyButtonPressed()
    {

    }


    static public void SavePartyButtonPressed2(string SaveName)
    {
        string equipData = "";

        DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\Temp\SaveFolder").GetDirectories();


        using (StreamWriter sw = new StreamWriter("c:/Temp/SaveFolder/"+ SaveName +".txt"))
        {

            foreach (PartyCharacter pc in GameContent.partyCharacters)
            {

                foreach (int equipID in pc.equipment)
                {
                    //sw.WriteLine(equipID);

                    equipData = equipData + equipID.ToString();
                    equipData = equipData + ",";
                }
                equipData.Remove(equipData.Length - 1);

                string charData = pc.classID.ToString() + "," + pc.health.ToString() + "," + pc.mana.ToString() + "," + pc.strength.ToString()
                    + "," + pc.agility.ToString() + "," + pc.wisdom.ToString() + "," + equipData + "999";
                //sw.WriteLine(pc.classID);
                //sw.WriteLine(pc.health);
                //sw.WriteLine(pc.mana);
                //sw.WriteLine(pc.strength);
                //sw.WriteLine(pc.agility);
                //sw.WriteLine(pc.wisdom);
                //foreach (int equipID in pc.equipment)
                //{
                //    sw.WriteLine(equipID);
                //}
                sw.WriteLine(charData);
                equipData = "";
            }
        }

        foreach (PartyCharacter pc in GameContent.partyCharacters)
        {
            Debug.Log("PC class id == " + pc.classID);
        }
    }

    static public void LoadPartyButtonPressed2(string LoadName)
    {

        GameContent.partyCharacters.Clear();

        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("c:/Temp/SaveFolder/" + LoadName + ".txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                for (int i = 0; i < 4; i++)
                {
                    string temp = sr.Peek().ToString();
                    Debug.Log("THIS IS TEMP" + temp);

                    if (temp != "")
                        // PLAY WITH THIS TO GET THE RIGHT AMOUNT OF CHARACTERS ACCORDING TO SAVE FILE
                        GameContent.partyCharacters.AddLast(new PartyCharacter());
                }

                foreach (PartyCharacter pc in GameContent.partyCharacters)
                {
                    string loadCharData = sr.ReadLine();

                    Debug.Log(loadCharData);

                    string[] broken_str = loadCharData.Split(',');

                    pc.classID = int.Parse(broken_str[0]);
                    pc.health = int.Parse(broken_str[1]);
                    pc.mana = int.Parse(broken_str[2]);
                    pc.strength = int.Parse(broken_str[3]);
                    pc.agility = int.Parse(broken_str[4]);
                    pc.wisdom = int.Parse(broken_str[5]);

                    pc.equipment.Clear();

                    if (broken_str[6] != "999")
                    {
                        Debug.Log("6" + int.Parse(broken_str[6]));
                        pc.equipment.AddLast(int.Parse(broken_str[6]));
                    }

                    if (broken_str[7] != "999")
                    {
                        Debug.Log("7" + int.Parse(broken_str[7]));
                        pc.equipment.AddLast(int.Parse(broken_str[7]));
                    }

                    if (broken_str[8] != "999")
                    {
                        Debug.Log("8" + int.Parse(broken_str[8]));
                        pc.equipment.AddLast(int.Parse(broken_str[8]));
                    }

                    if (broken_str[9] != "999")
                    {
                        Debug.Log("9" + int.Parse(broken_str[9]));
                        pc.equipment.AddLast(int.Parse(broken_str[9]));
                    }

                    for (int i = 0; i < broken_str.Length; i++)
                    {
                        broken_str[i] = "";
                    }







                    //pc.classID = int.Parse(sr.ReadLine());
                    //pc.health = int.Parse(sr.ReadLine());
                    //pc.mana = int.Parse(sr.ReadLine());
                    //pc.strength = int.Parse(sr.ReadLine());
                    //pc.agility = int.Parse(sr.ReadLine());
                    //pc.wisdom = int.Parse(sr.ReadLine());


                }

            }
        }

        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }



        GameContent.RefreshUI();

    }





}

#endregion
