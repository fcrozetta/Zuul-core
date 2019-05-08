using System;

namespace Zuul_Items
{
    abstract class Item
    {
        abstract public int Id { get; set; }
        abstract public string Name { get; set; }
        abstract public string Description { get; set; }
    }
}