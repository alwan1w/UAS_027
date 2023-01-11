using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_027
{
    class Program
    {
        class Node
        {
            public int idb;
            public string nama;
            public string jenis;
            public int harga;
            public Node next;
        }

        class list
        {
            Node START;
            public list()
            {
                START = null;
            }
            public void insert()
            {
                int id, hb;
                string naba, jb;
                Console.WriteLine("\nMasukkan ID Barang:  ");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nMasukkan Nama Barang:  ");
                naba = Console.ReadLine();
                Console.WriteLine("\nMasukkan Jenis Barang:  ");
                jb = Console.ReadLine();
                Console.WriteLine("\nMasukkan Harga Barang:  ");
                hb = Convert.ToInt32(Console.ReadLine());

                Node nodebaru = new Node();
                nodebaru.idb = id;
                nodebaru.nama = naba;
                nodebaru.jenis = jb;
                nodebaru.harga = hb;

                if (START == null || id <= START.idb)
                {
                    if ((START != null) && (id == START.idb))
                    {
                        Console.WriteLine("Nomer Barangnya sama tidak boleh");
                        return;
                    }
                    nodebaru.next = START;
                    START = nodebaru;
                    return;
                }

                Node previous, current;
                previous = START;
                current = START;

                while ((current != null) && (id >= current.idb))
                {
                    if (id == current.idb)
                    {
                        Console.WriteLine("Nomer Barangnya sama tidak boleh");
                        return;
                    }
                    previous = current;
                    current = current.next;
                }
                nodebaru.next = current;
                previous.next = nodebaru;
            }

            public bool Search(string jb,ref Node previous, ref Node current)
            {
                previous = START;
                current = START;

                while((current != null) && (jb != current.jenis))
                {
                    previous = current;
                    current = current.next;
                }
                
                if (current == null)
                    return (false);
                else
                    return (true);
            }
            public void traverse()
            {
                if (listEmpty())
                    Console.WriteLine("\nList kosong");
                else
                {
                    Console.WriteLine("\nData yang dilist adalah: ");
                    Console.Write("id barang" + "   " + "Nama barang" + "    " + "harga" + "   " + "Jenis" + "\n");
                    Node currentNode;
                    for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    {
                        Console.Write(currentNode.idb + "  " + currentNode.nama + "  " + currentNode.harga + "  " + currentNode.jenis + "\n");
                    }
                    Console.WriteLine();
                }
            }
            public bool listEmpty()
            {
                if (START == null)
                    return true;
                else
                    return false;
            }
        }
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan data kedalam list");
                    Console.WriteLine("2. Mencari sebuah data yang terdaftar");
                    Console.WriteLine("3. Melihat semua sebuah data yang terdaftar");
                    Console.WriteLine("4. Keluar bos");
                    Console.Write("\nMasukkan Pilihan Anda (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nKosong bang!!!");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.WriteLine("\nMasukkan jenis barang yang ingin dicari: ");
                                string jb = Convert.ToString(Console.ReadLine());
                                if (obj.Search(jb, ref previous, ref current) == false)
                                    Console.WriteLine("\ntidak ditemukan");
                                else
                                {
                                    
                                    
                                        Console.WriteLine("\ndata ditemukan");
                                        Console.WriteLine("\nId barang: " + current.idb);
                                        Console.WriteLine("\nHarga barang : " + current.harga);
                                        Console.WriteLine("\nNama Barang: " + current.nama);
                                        Console.WriteLine("\nJenis Barang: " + current.jenis);
                                    
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\npilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck data yang anda masukkan.");
                }
            }
        }
    }
}



//2. saya menggunakan algoritma singlelinkedlist yang karena terdapat menambah,mencari dan menampilkan data
//3. rear dan front
//4. a. terdapat 4 kedalaman
//   b. inorder Data tersebut dapat dibaca pada sebelah kiri dari induknya terlebih dahulu,
//   lalu dilanjut dengan data sebelah kanannya dari induk, lalu data dari induk tersebut