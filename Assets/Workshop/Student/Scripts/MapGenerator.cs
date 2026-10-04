using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable

        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map

            // 2. create obstacles


            // 3. create floor
            //int x = 1;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);
                    GameObject floor = Instantiate(floorTiles[r],
                        new Vector2(x, y),
                        Quaternion.identity);
                    floor.name = $"(x)-(y)";
                }
            }
            // 4. create walls
            for (int y = -1; y < rows + 1; y++)
            {
                for (int x = -1; x < columns + 1; x++)
                {
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        int r = UnityEngine.Random.Range(0, wallTiles.Length);
                        GameObject floor = Instantiate(wallTiles[r],
                            new Vector2(x, y),
                            Quaternion.identity);
                        floor.name = $"(x)-(y)";
                    }

                }
            }

            // 5. random foods
            int numberoffood = UnityEngine.Random.Range(1, 3);
            for (int i = 0; i < numberoffood; i++)
            {
                int randomX = UnityEngine.Random.Range(0, columns);
                int randomY = UnityEngine.Random.Range(0, rows);
                Instantiate(foodTiles[0],
                    new Vector2(randomX, randomY),
                    Quaternion.identity);

            }

            // 6. generate item along with the saveItemMap
            for (int y = 0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[y, x];
                    int foodIndex = -1;
                    for (int i = 0; i < foodIndex; i++)
                    {
                        if (foodTiles[i].name == item)
                        {
                            foodIndex = i;
                        }
                    }
                    if (foodIndex > -1)
                    {
                        Instantiate(foodTiles[foodIndex],
                            new Vector2(x, y),
                            Quaternion.identity);
                    }
                }
            }

            // 7. place exit

        }
    }

}