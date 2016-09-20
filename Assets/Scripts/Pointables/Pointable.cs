using UnityEngine;
using System.Collections;

public interface Pointable
{
    void OnPointerEnter();
    void OnPointerStay();
    void OnPointerExit();
}