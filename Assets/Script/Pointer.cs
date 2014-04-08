using UnityEngine;
using System.Collections;

public class Pointer {
  private int i;
  private int f;
  
  public Pointer() {
    i = 0;
    f = 0;
  }
  
  public Pointer(int f_, int i_) {
    i = i_;
    f = f_;
  }
  
  public int getF() {
    return f;
  }
  
  public int getI() {
    return i;
  }
}
