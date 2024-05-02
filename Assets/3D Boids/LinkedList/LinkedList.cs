using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList<T>
{
    private int count;
    public LinkedListNode<T> first, last;

    public void AddToFront(T data)
    {
      LinkedListNode<T> node = new LinkedListNode<T>();
      node.data = data;

      if(first is null)
      {
        first = last = node;
      } else {
        node.next = first;
        first.previous = node;
        first = node;
        count++;
      }
    }

    public void AddToBack(T data)
    {
      LinkedListNode<T> node = new LinkedListNode<T>();
      node.data = data;

      if(first is null)
      {
        first = last = node;
      } else {
        last.next = node;
        node.previous = last;
        last = node;
        count++;
      }
    }

    public void RemoveFirst()
    {
      if(count >= 0)
      {
        if(first.next is not null)
        {
          first = first.next;
          first.previous = null;
          count--;
        } else {
          first = last = null;
        }
      }
    }

    public void RemoveLast()
    {
      if(count >= 0)
      {
        if(last.previous is not null)
        {
          last = last.previous;
          last.next = null;
          count--;
        } else {
          first = last = null;
        }
      }
    }

    public bool Contains(T data)
    {
      LinkedListNode<T> currentNode = new LinkedListNode<T>();
      currentNode = last;
      for(int a = count; a >= 0; a--)
      {
        if(currentNode.Equals(data))
        {
          return true;
        }
        currentNode = currentNode.previous;
      }
      return false;
    }

    public T GetElementAt(int point)
    {
      LinkedListNode<T> tempNode = new LinkedListNode<T>();
      tempNode = first;
      for(int a = 0; a <= point; a++)
      {
        if(a == point)
        {
          return tempNode.data;
        }
        tempNode = tempNode.next;
      }
      Debug.LogError("Index was outside of the bounds of the Linked List");
      return first.data;
    }

    public void RemoveElement(T data)
    {
      LinkedListNode<T> tempNode = new LinkedListNode<T>();
      tempNode = first;
      for(int a = 0; a < count; a++)
      {
        if(tempNode.data.Equals(data))
        {
          if(tempNode.data.Equals(first.data))
          {
            RemoveFirst();
          } else if(tempNode.data.Equals(last.data))
          {
            RemoveLast();
          } else {
            tempNode.previous.next = tempNode.next;
            tempNode.next.previous = tempNode.previous;
            count--;
          }
          return;
        }
        tempNode = tempNode.next;
      }
      Debug.LogError("Linked List does not contain data to be removed");
    }

    private int GetPointOfData(T data)
    {
      LinkedListNode<T> tempNode = new LinkedListNode<T>();
      tempNode = first;
      for(int a = 0; a < count; a++)
      {
        if(tempNode.data.Equals(data))
        {
          return a;
        }
        tempNode = tempNode.next;
      }
      return 0;
    }

    public void RemoveElementAt(int point)
    {
      LinkedListNode<T> tempNode = new LinkedListNode<T>();
      tempNode = first;
      for(int a = 0; a <= point; a++)
      {
        if(a == point)
        {
          tempNode.previous.next = tempNode.next;
          tempNode.next.previous = tempNode.previous;
          Debug.Log(tempNode.data);
          Debug.Log(tempNode.next.data);
          Debug.Log(tempNode.previous.data);
          Debug.Log(tempNode.previous.next.data);
          Debug.Log(tempNode.next.previous.data);
          return;
        }
        tempNode = tempNode.next;
      }
      Debug.LogError("Index was outside of the bounds of the Linked List");
    }

    public T FirstElement()
    {
      return first.data;
    }

    public T LastElement()
    {
      return last.data;
    }

    public T PopFirst()
    {
      T temp = first.data;
      RemoveFirst();
      return temp;
    }

    public T PopLast()
    {
      T temp = last.data;
      RemoveLast();
      return temp;
    }

    public int Count()
    {
      return count;
    }
}
