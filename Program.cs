using System;
using System.Collections.Generic;

namespace AlainN_Algorithm_1_First_Version_MergeSort
{
    class Program
    {
        LinkedList<Node> contactList = new LinkedList<Node>();
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("This console app will let you create a contact list and order the contact list");
            p.AddContact();
            p.displayList();
            p.MergeSort();

        }

        public void AddContact()
        {
            //ask if user wants to add a contact
            Console.WriteLine("\nWould you like to add a contact? (y/n)");
            string response = Console.ReadLine();

            while(response.ToUpper() != "N")
            {
                Node node = new Node();
                //collect all contact info
                Console.Write("First Name: ");
                node.firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                node.lastName = Console.ReadLine();
                Console.Write("Phone Number: ");
                node.phoneNumber = Int32.Parse(Console.ReadLine());

                //store all contact info
                contactList.AddLast(node);

                //ask if they want to add more
                Console.WriteLine("\nWould you like to add a contact? (y/n)");
                response = Console.ReadLine();
            }
        }
        //display the unordered list of contacts
        public void displayList()
        {
            Console.WriteLine("\nHERE'S YOUR LIST OF CONTACTS:");
            foreach(var contacts in contactList)
            {
                Console.WriteLine($"{contacts.firstName} {contacts.lastName}");
                Console.WriteLine(contacts.phoneNumber);
                Console.WriteLine();
            }
        }
        //merge sort the contacts
        public void MergeSort()
        {

        }
    }

    class Node
    {
        public string firstName;
        public string lastName;
        public int phoneNumber;
    }
}
