
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

