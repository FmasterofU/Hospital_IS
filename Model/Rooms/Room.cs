// File:    Room.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;

namespace Model.Rooms
{
   public class Room : Repository.IIdentifiable<uint>
   {
      private uint id;
      private RoomType type;
      private string name;

        public Room(RoomType type, string name, List<ItemCount> itemCount)
        {
            this.id = 0;
            this.type = type;
            this.name = name;
            this.itemCount = itemCount;
        }

        public RoomType Type
      {
         get
         {
            return type;
         }
         set
         {
            this.type = value;
         }
      }
      
      public string Name
      {
         get
         {
            return name;
         }
         set
         {
            this.name = value;
         }
      }
      
      public System.Collections.Generic.List<ItemCount> itemCount;
      
      /// <summary>
      /// Property for collection of ItemCount
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<ItemCount> ItemCount
      {
         get
         {
            if (itemCount == null)
               itemCount = new System.Collections.Generic.List<ItemCount>();
            return itemCount;
         }
         set
         {
            RemoveAllItemCount();
            if (value != null)
            {
               foreach (ItemCount oItemCount in value)
                  AddItemCount(oItemCount);
            }
         }
      }
      
      /// <summary>
      /// Add a new ItemCount in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddItemCount(ItemCount newItemCount)
      {
         if (newItemCount == null)
            return;
         if (this.itemCount == null)
            this.itemCount = new System.Collections.Generic.List<ItemCount>();
         if (!this.itemCount.Contains(newItemCount))
            this.itemCount.Add(newItemCount);
      }
      
      /// <summary>
      /// Remove an existing ItemCount from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveItemCount(ItemCount oldItemCount)
      {
         if (oldItemCount == null)
            return;
         if (this.itemCount != null)
            if (this.itemCount.Contains(oldItemCount))
               this.itemCount.Remove(oldItemCount);
      }
      
      /// <summary>
      /// Remove all instances of ItemCount from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllItemCount()
      {
         if (itemCount != null)
            itemCount.Clear();
      }

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }
    }
}