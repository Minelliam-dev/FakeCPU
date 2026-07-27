
//Main function
void run(sbyte[] Instructions)
{
    //Storage
    sbyte StorageInt = 0;
    sbyte UserStorage = 0;
    sbyte InputStorage = 0;
    
    //Next instruction variables
    bool SkipInstruction = false;
    sbyte NextInstructionForced = 0;
    
    //Loop variables
    sbyte LoopInstruction = -1;
    sbyte LoopIteration = -1;
    
    //just a for loop to run the instructions
    foreach (sbyte CurrentInstructionRaw in Instructions)
    {
        //make copy of the Current instruction variable because the original cannot be modified
        sbyte CurrentInstruction = CurrentInstructionRaw;
        
        if (StorageInt == 6)
        {
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
        if (StorageInt == 3 && LoopIteration == -1)
        {
            LoopInstruction = CurrentInstruction;
            SkipInstruction = true;
        }
        
        if (StorageInt == 3 && UserStorage != LoopIteration)
        {
            CurrentInstruction = LoopInstruction;
            LoopIteration += 1;
        }
        else if (UserStorage == LoopIteration)
        {
            LoopIteration = -1;
            LoopInstruction = -1;
            StorageInt = 0;
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
            else if (CurrentInstruction == 5 && LoopInstruction == -1)
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

        }
        //Reset the SkipInstruction Variable
        SkipInstruction = false;
        
    }
}

/*

The entire language uses 8 bit int variables, so the variables can only be in a range of -128 to 127

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

*/

//Instructions
sbyte[] InstructionList = {12, 13, 6};

sbyte[] program =
{
    12,       // Get input
    13,       // Copy input to UserStorage

    9,        // If UserStorage is zero...
    1,        // ...activate print mode

    100,      // Printed only if print mode activated
    2         // End print mode
};

sbyte[] TestProgram = {1, 5, 2, 3, 100, 5, 1, 0, 0, 2, 6, 7, 3, 5, 3, 0, 6, 9, 1, 5, 2, 10, -2, 6, 11, 6};

//start the execution
run(program);
