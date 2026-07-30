FakeCPU is a custom C# assembly language and emulator made for learning purposes.

The entire language uses 8 bit int variables, so the variables can only be in a range of -128 to 127

Commands:

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


