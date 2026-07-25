
//Main function
void run(Int16[] Instructions)
{
    //Storage
    Int16 StorageInt = 0;
    Int16 UserStorage = 0;
    
    //Next instruction variables
    bool SkipInstruction = false;
    Int16 NextInstructionForced = 0;
    
    //Loop variables
    Int16 LoopInstruction = 0;
    Int16 LoopIteration = -1;

    //IF variables
    Int16 IFFunction = -1;
    
    
    //just a for loop to run the instructions
    foreach (Int16 CurrentInstructionRaw in Instructions)
    {
        //make copy of the Current instruction variable because the original cannot be modified
        Int16 CurrentInstruction = CurrentInstructionRaw;
        
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
            StorageInt = 0;
        }

        //IF mode
        if (StorageInt == 4)
        {
            if (UserStorage != 0)
            {
                SkipInstruction = true;
            }
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

        }
        //Reset the SkipInstruction Variable
        SkipInstruction = false;
        
    }
}

/*

The entire language uses 16 bit int variables, so the
highest variable can only be up to 32767

1 = Enable console output and make any instruction after be printed as a number
2 = Disable any active mode that is currently active
3 = Enable variable mode and save the next instruction into a variable
4 = Run the saved instruction
5 = Activate the loop mode, in loop mode the next instruction is repeated as many times specified in the user variable
6 = Write the User variable to the terminal
7 = Clear the terminal
8 = Pause execution for seconds specified by the user variable 
9 = Activate IF mode, when in IF mode, the next instruction is the instruction that will run, if the user variable is 0

*/

//Instructions
Int16[] InstructionList = {1, 5, 2, 3, 100, 5, 1, 0, 0, 2, 6, 7, 3, 5, 3, 0, 6, 9, 1, 5};


//start the execution
run(InstructionList);