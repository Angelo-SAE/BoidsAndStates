using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLinkedList : MonoBehaviour
{
    private LinkedList<int> list;
    [SerializeField] private List<int> showList;
    [SerializeField] private int removeAt;

    private void Start()
    {
      list = new LinkedList<int>();
      showList = new List<int>();
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.Q))
      {
        int data = Random.Range(0,10);
        list.AddToFront(data);
        showList.Insert(0, data);
      }
      if(Input.GetKeyDown(KeyCode.W))
      {
        int data = Random.Range(0,10);
        list.AddToBack(data);
        showList.Add(data);
      }
      if(Input.GetKeyDown(KeyCode.E))
      {
        Debug.Log(list.FirstElement());
      }
      if(Input.GetKeyDown(KeyCode.R))
      {
        Debug.Log(list.LastElement());
      }
      if(Input.GetKeyDown(KeyCode.T))
      {
        Debug.Log(list.PopFirst());
        showList.RemoveAt(0);
      }
      if(Input.GetKeyDown(KeyCode.Y))
      {
        Debug.Log(list.PopLast());
        showList.RemoveAt(showList.Count - 1);
      }
      if(Input.GetKeyDown(KeyCode.A))
      {
        list.RemoveFirst();
        showList.RemoveAt(0);
      }
      if(Input.GetKeyDown(KeyCode.S))
      {
        list.RemoveLast();
        showList.RemoveAt(showList.Count - 1);
      }
      if(Input.GetKeyDown(KeyCode.Z))
      {
        if(showList.Contains(5))
        {
          Debug.Log("it Contains 5");
        }
      }
      if(Input.GetKeyDown(KeyCode.X))
      {
        list.RemoveElementAt(removeAt);
        showList.RemoveAt(removeAt);
      }
      if(Input.GetKeyDown(KeyCode.C))
      {
        list.RemoveElement(removeAt);
        for(int a = 0; a < showList.Count; a++)
        {
          if(showList[a] == removeAt)
          {
            showList.RemoveAt(a);
          }
        }
      }
    }
}
