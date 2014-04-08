using UnityEngine;
using System.Collections;

public class Program : MonoBehaviour {
  private int f;
  private int i;
  private ArrayList<Pointer>pointers;
  private ArrayList<Instruction> functions;
  
  public Program(int[] lengths) {
    f = 0;
    i = 0;
    pointers = new ArrayList<Pointer[]>();
    functions = new ArrayList<Instruction[]>();
    for (int l : lengths) {
      functions.add(createFunction(l));
    }
  }
  
  public Instruction[] createFunction(length) {
    Instruction[] instructions = new Instruction[](length);
    for(int x = 0; x < length; x++)
    {
      instructions[x] = new Instruction();
    }
    
    return instructions;
  }
  
  public Instruction getCurrent() {
    return functions.get(f)[i];
  }
  
  public boolean isAtEndOfFunction() {
    return i >= functions.get(f).length || !getCurrent().hasCommand();
  }
  
  public boolean hasNext() {
    return pointers.size() > 0 || !isAtEndOfFunction();
  }
  
  public Instruction getNext(bot) {
    if(!hasNext()) {
      i++;
      return null;
    }
    
    if(isAtEndOfFunction()) {
      Pointer pointer = pointers.pop();
      f = pointer.getF();
      i = pointer.getI();
      return getNext(bot);
    }
    
    Instruction inst = getCurrent();
    
    if (!inst.passesCondition(bot)) {
      i++;
      return getNext(bot);
    }
    
    if (inst.isFunctionCall()) {
      pointers.add(new Pointer(f, i+1));
      f = inst.getFunctionCall();
      i = 0;
      return inst;
    }
    
    i++;
    return inst;
  }
  
  public void rollback(ArrayList<Pointers> pointerState, int iState, int fState) {
    pointers = pointerState;
    f = fState;
    i = iState;
  }
  
  public int getCurrentInstruction() {
    return i;
  }
  
  public int getCallerFunction() {
    if (pointers.size() == 0)
      return -1;
    return pointers.get(0).getF();
  }
  
  public int getCallerInstruction() {
    if (pointers.size() == 0)
      return -1;
    return pointers.get(0).getI();
  }
  
  public void reset() {
    f = 0;
    i = 0;
    pointers = new ArrayList<Pointer[]>();
  }
  
  public void clear() {
    for(Instruction[] func : functions) {
      for (Instruction inst : func) {
        inst.setCommand(-1);
        inst.setCondition(-1);
      }
    }
  }
}
