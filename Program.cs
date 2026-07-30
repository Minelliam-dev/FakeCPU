string[] AsciiChar = {" ", "!", "", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?", "@", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "^", "_", "`", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "{", "|", "}", "~"};

//Main function
void run(int[] Instructions)
{
    //Storage
    int StorageInt = 0;
    int UserStorage = 0;
    int InputStorage = 0;
    int[] UserMemory = new int[10];
    string OutputString = "";

    //Memory Change variables
    bool ChangingUserMemory = false;
    bool NeededValue = false;
    int[] Values = {-1, -1};
    
    //Next instruction variables
    bool SkipInstruction = false;
    int NextInstructionForced = 0;
    bool SkipStorageIntExecution = false;
    
    //Loop variables
    int RepeatCount = 0;
    int RepeatInstruction = 0;
    int RepeatedI = 0;
    int RepeatedCount = 0;
    int GlobalI = 0;
    
    //just a for loop to run the instructions
    while (GlobalI+1 <= Instructions.Length)
    {
        int CurrentInstructionRaw = Instructions[GlobalI];
        GlobalI++;

        //make copy of the Current instruction variable because the original cannot be modified
        int CurrentInstruction = CurrentInstructionRaw;
        
        
        //Check if the Storage int should be skipped and if so, return false
        if (!SkipStorageIntExecution)
        {
            if (StorageInt == 6)
            {
                int number = int.Parse(Console.ReadLine()!);

                InputStorage = number;
                StorageInt = 0;

            }

            //Check if the next instruction is forced and if so, change the current instruction
            if (NextInstructionForced != 0)
            {
                CurrentInstruction = NextInstructionForced;
                NextInstructionForced = 0;
            }

            //Check if in print mode
            if (StorageInt == 1 && CurrentInstruction != 2)
            {
                Console.WriteLine(CurrentInstruction.ToString());
                SkipInstruction = true;
            }

            //Check if in variable mode
            if (StorageInt == 2)
            {
                StorageInt = 0;
                UserStorage = CurrentInstruction;
                SkipInstruction = true;
            }


            //Loops..........
            if (StorageInt == 3 && RepeatCount == 0)
            {
                RepeatCount = CurrentInstruction;
                SkipInstruction = true;
            }
            else if (StorageInt == 3 && RepeatCount != 0 && RepeatedI == 0)
            {
                RepeatedI = GlobalI;
                RepeatInstruction = CurrentInstruction;
            }
            else if (RepeatedI != 0 && RepeatedCount < RepeatCount)
            {
                RepeatedCount += 1;
                CurrentInstruction = RepeatInstruction;
                GlobalI -= 1;
            }
            else if (RepeatedI != 0 && RepeatedCount >= RepeatCount)
            {
                StorageInt = 0;

                RepeatCount = 0;
                RepeatInstruction = 0;
                RepeatedI = 0;
                RepeatedCount = 0;
            }


            //IF mode
            if (StorageInt == 4)
            {
                StorageInt = 0;

                if (UserStorage != 0)
                {
                    SkipInstruction = true;
                }
            }

            if (StorageInt == 5)
            {
                UserStorage += CurrentInstruction;
                SkipInstruction = true;
                StorageInt = 0;
            }
        
            if (StorageInt == 7 && NeededValue == false && ChangingUserMemory)
            {
                Values[0] = CurrentInstruction;
                SkipInstruction = true;
                NeededValue = true;
            }
            else if (StorageInt == 7 && NeededValue && ChangingUserMemory && Values[1] == -1)
            {
                Values[1] = CurrentInstruction;
                SkipInstruction = true;
            }
            else if (StorageInt == 7 && NeededValue && ChangingUserMemory && Values[1] != -1)
            {
                UserMemory[Values[0]] = Values[1];

                NeededValue = false;
                ChangingUserMemory = false;
                Values = new int[] {-1, -1};
                StorageInt = 0;
            }

            if (StorageInt == 8)
            {
                UserStorage = UserMemory[CurrentInstruction];
                SkipInstruction = true;
                StorageInt = 0;
            }

            if (StorageInt == 9)
            {
                UserStorage += UserMemory[CurrentInstruction];
                SkipInstruction = true;
                StorageInt = 0;
            }

            if (StorageInt == 10)
            {
                OutputString += AsciiChar[CurrentInstruction];
                SkipInstruction = true;
                StorageInt = 0;
            }

            if (StorageInt == 11)
            {
                if (UserStorage == 0)
                {
                    GlobalI = CurrentInstruction;
                }

                SkipInstruction = true;
                StorageInt = 0;
            }
        
        
        }
        //reset the SkipStorageIntExecution variable
        SkipStorageIntExecution = false;
        
        
        //check if execution should be skipped
        if (!SkipInstruction)
        {
            //enable output mode
            if (CurrentInstruction == 1)
            {
                StorageInt = 1;
            }
            
            //Reset the current mode
            else if (CurrentInstruction == 2)
            {
                StorageInt = 0;
            }
            
            //Activate variable mode
            else if (CurrentInstruction == 3)
            {
                StorageInt = 2;
            }
            
            //Run the instruction in the user variable
            else if (CurrentInstruction == 4)
            {
                NextInstructionForced = UserStorage;
            }

            //Activate the loop mode
            else if (CurrentInstruction == 5 && RepeatInstruction == 0)
            {
                StorageInt = 3;
            }

            //Print the UserVariable
            else if (CurrentInstruction == 6)
            {
                Console.WriteLine(UserStorage.ToString());
            }

            //Clear the terminal
            else if (CurrentInstruction == 7)
            {
                Console.Clear();
            }

            //Pause execution for the amount of seconds in the user variable
            else if (CurrentInstruction == 8)
            {
                Thread.Sleep(1000 * UserStorage);
            }

            //activate IF mode
            else if (CurrentInstruction == 9)
            {
                StorageInt = 4;
            }

            //activate Add mode
            else if (CurrentInstruction == 10)
            {
                StorageInt = 5;
            }

            //reset the user variable
            else if (CurrentInstruction == 11)
            {
                UserStorage = 0;
            }

            //Enable Input mode for one instruction
            else if (CurrentInstruction == 12)
            {
                StorageInt = 6;
            }
            
            //Set the user variable to the input variable
            else if (CurrentInstruction == 13)
            {
                UserStorage = InputStorage;
            }

            //Skip the next storage variable check
            else if (CurrentInstruction == 14)
            {
                SkipStorageIntExecution = true;
            }

            //jump
            else if (CurrentInstruction == 15)
            {
                GlobalI = UserStorage;
            }
            
            //Change user memory
            else if (CurrentInstruction == 16)
            {
                StorageInt = 7;
                ChangingUserMemory = true;
            }

            //Get user memory position
            else if (CurrentInstruction == 17)
            {
                StorageInt = 8;
            }

            //Add user memory position to the user variable
            else if (CurrentInstruction == 18)
            {
                StorageInt = 9;
            }

            //Add input storage to the user variable
            else if (CurrentInstruction == 19)
            {
                UserStorage += InputStorage;
            }


            //Add a letter to the output string variable
            else if (CurrentInstruction == 20)
            {
                StorageInt = 10;
            }

            //Print the output string
            else if (CurrentInstruction == 21)
            {
                Console.WriteLine(OutputString);
            }

            //reset the output string
            else if (CurrentInstruction == 22)
            {
                OutputString = "";
            }


            //New if
            else if (CurrentInstruction == 23)
            {
                StorageInt = 11;
            }
        }
        //Reset the SkipInstruction Variable
        SkipInstruction = false;
        
    }
}


int[] ConvertToInstructions(string[] StringInstructionList)
{
    int[] FinalExport = new int[StringInstructionList.Length];
    
    for (int i=0; StringInstructionList.Length > i; i++)
    {
        string InstructionString = StringInstructionList[i];
        
        if (InstructionString.StartsWith("R") &&
            int.TryParse(InstructionString[1..], out int rawValue))
        {
            FinalExport[i] = rawValue;
            continue;
        }
        
        
        
        
        
        if (InstructionString == "OUT")
        {
            FinalExport[i] = 1;
        }
        else if (InstructionString == "DEL")
        {
            FinalExport[i] = 2;
        }
        else if (InstructionString == "SAV")
        {
            FinalExport[i] = 3;
        }
        else if (InstructionString == "RSI")
        {
            FinalExport[i] = 4;
        }
        else if (InstructionString == "LOP")
        {
            FinalExport[i] = 5;
        }
        else if (InstructionString == "PUV")
        {
            FinalExport[i] = 6;
        }
        else if (InstructionString == "CLS")
        {
            FinalExport[i] = 7;
        }
        else if (InstructionString == "PSE")
        {
            FinalExport[i] = 8;
        }
        else if (InstructionString == "IFJ")
        {
            FinalExport[i] = 9;
        }
        else if (InstructionString == "ADD")
        {
            FinalExport[i] = 10;
        }
        else if (InstructionString == "RES")
        {
            FinalExport[i] = 11;
        }
        else if (InstructionString == "INP")
        {
            FinalExport[i] = 12;
        }
        else if (InstructionString == "GIN")
        {
            FinalExport[i] = 13;
        }
        else if (InstructionString == "SKP")
        {
            FinalExport[i] = 14;
        }
        else if (InstructionString == "JMP")
        {
            FinalExport[i] = 15;
        }
        else if (InstructionString == "CMR")
        {
            FinalExport[i] = 16;
        }
        else if (InstructionString == "GMR")
        {
            FinalExport[i] = 17;
        }
        else if (InstructionString == "ADM")
        {
            FinalExport[i] = 18;
        }
        else if (InstructionString == "ADI")
        {
            FinalExport[i] = 19;
        }
        else if (InstructionString == "ASC")
        {
            FinalExport[i] = 20;
        }
        else if (InstructionString == "POS")
        {
            FinalExport[i] = 21;
        }
        else if (InstructionString == "ROS")
        {
            FinalExport[i] = 22;
        }
        else if (InstructionString == "JIZ")
        {
            FinalExport[i] = 23;
        }
    }

    return FinalExport;
}



/*

Also the list of ascii letters had to be altered to work in c# see the ascii variable at the top of the script for more info

Raw instruction commands:

1 = Enable console output and make any instruction after be printed as a number
2 = Disable any active mode that is currently active
3 = Enable variable mode and save the next instruction into a variable
4 = Run the saved instruction
5 = Activate the loop mode, in loop mode the next instruction is repeated as many times specified in the user variable
6 = Write the User variable to the terminal
7 = Clear the terminal
8 = Pause execution for seconds specified by the user variable 
9 = Activate IF mode, when in IF mode, the next instruction is the instruction that will run, if the user variable is 0
10 = activate Add mode adding the next instruction to the user variable
11 = Reset the user variable
12 = Activate input for one iteration
13 = set the user variable to the input variable
14 = Skip the next storage variable check
15 = Jump to the instruction saved in the user variable
16 = Set a value in user memory based on the next Instruction as position and the one after as the new value
17 = Set the user variable to a position in the user memory based on the next instruction
18 = Add a position in the user memory to the user variable
19 = Add the input variable to the user variable
20 = Add an ascii letter to the output string variable
21 = Print the output string variable
22 = Reset the Output string variable
23 = Jump to a location if the user variable is zero

String instructions:

OUT = Enable console output and make any instruction after be printed as a number
DEL = Disable any active mode that is currently active
SAV = Enable variable mode and save the next instruction into a variable
RSI = Run the saved instruction
LOP = Activate the loop mode, in loop mode the next instruction is repeated as many times specified in the user variable
PUV = Write the User variable to the terminal
CLS = Clear the terminal
PSE = Pause execution for seconds specified by the user variable 
IFJ = Activate IF mode, when in IF mode, the next instruction is the instruction that will run, if the user variable is 0
ADD = activate Add mode adding the next instruction to the user variable
RES = Reset the user variable
INP = Activate input for one iteration
GIN = set the user variable to the input variable
SKP = Skip the next storage variable check
JMP = Jump to the instruction saved in the user variable
CMR = Set a value in user memory based on the next Instruction as position and the one after as the new value
GMR = Set the user variable to a position in the user memory based on the next instruction
ADM = Add a position in the user memory to the user variable
ADI = Add the input variable to the user variable
ASC = Add an ascii letter to the output string variable
POS = Print the output string variable
ROS = Reset the Output string variable
JIZ = Jump to a location if the user variable is zero

*/

string[] StringInstructions =
{

};



//Convert the string array to an int array
int[] StringInstructionTest = ConvertToInstructions(StringInstructions);

//start the execution
run(StringInstructionTest);
