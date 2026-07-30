
//Main function
void run(sbyte[] Instructions)
{
    //Storage
    sbyte StorageInt = 0;
    sbyte UserStorage = 0;
    sbyte InputStorage = 0;
    sbyte[] UserMemory = new sbyte[10];

    //Memory Change variables
    bool ChangingUserMemory = false;
    bool NeededValue = false;
    sbyte[] Values = {-1, -1};
    
    //Next instruction variables
    bool SkipInstruction = false;
    sbyte NextInstructionForced = 0;
    bool SkipStorageIntExecution = false;
    
    //Loop variables
    sbyte RepeatCount = 0;
    sbyte RepeatInstruction = 0;
    sbyte RepeatedI = 0;
    sbyte RepeatedCount = 0;
    sbyte GlobalI = 0;
    
    //just a for loop to run the instructions
    while (GlobalI+1 <= Instructions.Length)
    {
        sbyte CurrentInstructionRaw = Instructions[GlobalI];
        GlobalI++;

        //make copy of the Current instruction variable because the original cannot be modified
        sbyte CurrentInstruction = CurrentInstructionRaw;
        
        
        //Check if the Storage int should be skipped and if so, return false
        if (!SkipStorageIntExecution)
        {
            if (StorageInt == 6)
            {
                Console.SetCursorPosition(0, 0);
                sbyte number = sbyte.Parse(Console.ReadLine()!);

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
            else if (RepeatedCount >= RepeatCount)
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
                Values = new sbyte[] {-1, -1};
                StorageInt = 0;
            }

            if (StorageInt == 8)
            {
                UserStorage = UserMemory[CurrentInstruction];
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

        }
        //Reset the SkipInstruction Variable
        SkipInstruction = false;
        
    }
}


sbyte[] ConvertToInstructions(string[] StringInstructionList)
{
    sbyte[] FinalExport = new sbyte[StringInstructionList.Length];
    
    for (int i=0; StringInstructionList.Length > i; i++)
    {
        string InstructionString = StringInstructionList[i];
        
        if (InstructionString.StartsWith("R") &&
            sbyte.TryParse(InstructionString[1..], out sbyte rawValue))
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
    }

    return FinalExport;
}





/*

The entire language uses 8 bit int variables, so the variables can only be in a range of -128 to 127


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


*/


//string instruction tests


string[] StringInstructions = 
{
"CLS",
"OUT", "R3", "DEL",

"RES"

};

//Convert the string array to an sbyte array
sbyte[] StringInstructionTest = ConvertToInstructions(StringInstructions);

//Raw Instructions
sbyte[] InstructionList = {1, 3};

sbyte[] TestProgram = {1, 5, 2, 3, 100, 5, 1, 0, 0, 2, 6, 7, 3, 5, 3, 0, 6, 9, 1, 5, 2, 10, -2, 6, 11, 6};

//start the execution
run(StringInstructionTest);
