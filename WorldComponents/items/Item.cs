using System;

namespace zuul_core
{
    abstract class Item
    {
        abstract public int Id { get; set; }
        abstract public string Name { get; set; }
        abstract public string Description { get; set; }
    }
}