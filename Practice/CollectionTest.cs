using System;
using System.Collections; // collections 안의 자료구조를 활용하자

class CollectionTest
{
    public static void Run()
    {
        // 다양한 타입의 데이터를 크기 제한 없이 동적으로 관리하는 ArrayList
        ArrayList al = new ArrayList();

        al.Add(3);
        al.Add("hello");
        al.Add(3.5);
        al.Add(true);

        Console.WriteLine("before");
        foreach (var item in al)
        {
            Console.WriteLine(item);
        }

        al.Remove("hello");

        Console.WriteLine("after");
        foreach (var item in al)
        {
            Console.WriteLine(item);
        }

        // 데이터를 순차적으로 보관하는 Queue
        Queue qu = new Queue();

        qu.Enqueue(1);
        qu.Enqueue(2);
        qu.Enqueue(3);

        // 먼저 들어온 데이터가 먼저 나가는 선입선출(FIFO) 방식
        while (qu.Count > 0)
        {
            Console.WriteLine(qu.Dequeue());
        }

        // 데이터를 차곡차곡 쌓아 올리는 Stack
        Stack st = new Stack();

        st.Push(1);
        st.Push(2);
        st.Push(3);

        // 나중에 들어온 데이터가 먼저 나가는 후입선출(LIFO) 방식
        while (st.Count > 0)
        {
            Console.WriteLine(st.Pop());
        }

        // 데이터를 고유한 키(Key)와 값(Value)의 쌍으로 묶어서 관리하는 Hashtable
        Hashtable ht = new Hashtable();
        ht["apple"] = "사과";
        ht["banana"] = "바나나";
        ht["orange"] = "오렌지";

        // 저장할 때 사용한 고유 키를 통해 매칭되는 데이터(Value)에 즉시 접근한다.
        Console.WriteLine(ht["apple"]);
        Console.WriteLine(ht["banana"]);
        Console.WriteLine(ht["orange"]);
    }
}