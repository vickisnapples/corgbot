using UnityEngine;
using System.Collections;

public class Instruction {
  enum Command {LEFT, RIGHT, DOWN, F0, F1, F2, F3};
  enum Condition {PURPLE, ORANGE, BLUE, NONE}
  
  private int command;
  private int condition;
  
  public Instruction {
    command = -1;
    condition = -1;
  }
  
  public boolean hasCommand() {
    return command >= 0;
  }
  
  public boolean hasCondition() {
    return condition >= 0;
  }
  
  public boolean passesCondition(bot) {
    switch (Condition) {
      case Condition.PURPLE:
      case Condition.ORANGE:
      case Condition.BLUE:
      case Condition.NONE:
    }
    return true;
  }
  
  public boolean isFunctionCall() {
    return command == (int)Command.F0 ||
      command == (int)Command.F1 ||
      command == (int)Command.F2 ||
      command == (int)Command.F3;
  }
  
  public int getFunctionCall() {
    return command;
  }
}
