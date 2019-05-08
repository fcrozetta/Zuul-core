using System;

namespace Zuul_Item_Behavior
{
    interface IInteractable
    {
        Boolean IsInteractable { get; set; }
        (int status, string message) interact();
    }
}