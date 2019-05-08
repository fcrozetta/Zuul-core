using System;
using System.Collections.Generic;
using zuul_core;

namespace Zuul_Item_Behavior
{
    interface IUsable
    {
        Boolean IsUsable { get; set; }
        int UsableWith { get; set; }
        (int status, string message) use(Player player, List<Item> items);
    }
}