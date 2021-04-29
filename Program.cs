
using System;
using System.Collections.Generic;

namespace AlainN_Algorithm_1_First_Version_MergeSort
{
    class Program
    {
        LinkedList<GroupsOfContact> contactList = new LinkedList<GroupsOfContact>();
		LinkedListNode head = null;
		static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("This console app will let you create a contact list and order the contact list");
            p.AddContact();
            p.displayList();
			p.mergeSort();
		}

        public void AddContact()
        {
            //ask if user wants to add a contact
            Console.WriteLine("\nWould you like to add a contact? (y/n)");
            string response = Console.ReadLine();

            while (response.ToUpper() != "N")
            {
                GroupsOfContact goc = new GroupsOfContact();
                //collect all contact info
                Console.Write("First Name: ");
                goc.firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                goc.lastName = Console.ReadLine();
                Console.Write("Phone Number: ");
                goc.phoneNumber = Int32.Parse(Console.ReadLine());

                //store all contact info
                contactList.AddLast(goc);

                //ask if they want to add more
                Console.WriteLine("\nWould you like to add a contact? (y/n)");
                response = Console.ReadLine();
            }
        }
        //display the unordered list of contacts
        public void displayList()
        {
            Console.WriteLine("\nHere's your UNSORTED list of contacts:");
            foreach (var contacts in contactList)
            {
                Console.WriteLine($"Name: {contacts.firstName} {contacts.lastName}");
                Console.WriteLine($"Number: {contacts.phoneNumber}");
                Console.WriteLine();
            }
        }

		/* 
		 * From this point, the code that I used is mostly from
		 * https://www.geeksforgeeks.org/merge-sort-for-linked-list/
		 * and from the mergesort video presentation
		 */
		public void mergeSort()
        {
			Program li = new Program();
			/*
			* Let us create a unsorted linked list to test the functions
			* created. The list shall be a: 2->3->20->5->10->15
			*/
			foreach (var contacts in contactList)
			{
				li.push(contacts.firstName, contacts.lastName, contacts.phoneNumber);
			}

			// Apply merge Sort
			li.head = li.mergeSort(li.head);
			Console.WriteLine("\nHere's your MERGE SORTED list of contacts: ");
			li.printList(li.head);
		}

		// node a, b;
		public class LinkedListNode
		{
			public string firstName;
			public string lastName;
			public int phoneNumber;
			public LinkedListNode next;

			public LinkedListNode(string firstName, string lastName, int phoneNumber)
			{
				this.firstName = firstName;
				this.lastName = lastName;
				this.phoneNumber = phoneNumber;
			}
		}

		LinkedListNode sortedMerge(LinkedListNode a, LinkedListNode b)
		{
			LinkedListNode result = null;
			/* Base cases */
			if (a == null)
				return b;
			if (b == null)
				return a;

			/* Pick either a or b, and recur */
			if (string.Compare(a.firstName, b.firstName) == 0 || string.Compare(a.firstName, b.firstName) == -1)
			{
				result = a;
				result.next = sortedMerge(a.next, b);
			}
			else
			{
				result = b;
				result.next = sortedMerge(a, b.next);
			}
			return result;
		}

		LinkedListNode mergeSort(LinkedListNode cur)
		{
			// Base case : if head is null
			if (cur == null || cur.next == null)
			{
				return cur;
			}

			// get the middle of the list
			LinkedListNode middle = getMiddle(cur);
			LinkedListNode middleNext = middle.next;

			// set the next of middle node to null
			middle.next = null;

			// Apply mergeSort on left list
			LinkedListNode left = mergeSort(cur);

			// Apply mergeSort on right list
			LinkedListNode right = mergeSort(middleNext);

			// Merge the left and right lists
			LinkedListNode sortedlist = sortedMerge(left, right);
			return sortedlist;
		}

		// Utility function to get the
		// middle of the linked list
		LinkedListNode getMiddle(LinkedListNode h)
		{
			// Base case
			if (h == null)
				return h;
			LinkedListNode fastptr = h.next;
			LinkedListNode slowptr = h;

			// Move fastptr by two and slow ptr by one
			// Finally slowptr will point to middle node
			while (fastptr != null)
			{
				fastptr = fastptr.next;
				if (fastptr != null)
				{
					slowptr = slowptr.next;
					fastptr = fastptr.next;
				}
			}
			return slowptr;
		}

		void push(string new_fName, string new_lName, int new_pNum)
		{
			/* allocate node */
			LinkedListNode new_node = new LinkedListNode(new_fName, new_lName, new_pNum);

			/* link the old list off the new node */
			new_node.next = head;

			/* move the head to point to the new node */
			head = new_node;
		}

		// Utility function to print the linked list
		void printList(LinkedListNode headref)
		{
			while (headref != null)
			{
				Console.WriteLine($"Name: {headref.firstName} {headref.lastName}");
				Console.WriteLine($"Number: {headref.phoneNumber}");
				Console.WriteLine();
				headref = headref.next;
			}
		}
	}

	//A class that groups the contact info to be stored in a single node
    class GroupsOfContact
    {
        public string firstName;
        public string lastName;
        public int phoneNumber;
    }
}
