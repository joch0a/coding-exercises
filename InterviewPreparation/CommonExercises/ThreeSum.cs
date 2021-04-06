using System;
using System.Collections.Generic;

namespace InterviewPreparation.Exercises
{
    public class ThreeSumClass
    {
        //La idea detras del algoritmo es, basandose en 2Sum, sabiendo que el arreglo esta ordenado podemos hacer uso de 2 pointers strategy. Si a uno de los a b o c lo dejamos
        // fijo podemos hace 2sum
        // La idea de esto es que llevando 2 punteros en cada extremo del arreglo sabemos que si nums[low] + nums[high] > sum entonces debemos decrementar nuestro punteor en high
        // por ejemplo dado el siguiente arreglo: -1 -1 0 1 4 
        // Sabiendo que a + b + c = 0 => a + b = -c
        // Si a -1 (nuestro primer elemento) lo dejamos fijo, buscaremos una tupla a + b = - (-1) = 1
        // En la primer iteracion arrancaremos con nuestro low en la posicion 1 y nuestro high en la posicion 4
        // dado arr[1] = -1, arr[4] = 4, tenemos que -1 + 4 = 3, sabemos que debemos decrementar nuestro puntero de la derecha. Y asi con el resto del algoritmo
        // Algunos chequeos para actualizar los punteros son para evitar duplicados y por ultimo prestar atencion a la condicion de corte del for: nums.Length - 2.

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    var low = i + 1;
                    var high = nums.Length - 1;
                    var sum = -nums[i];

                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            result.Add(new List<int>() { -sum, nums[low], nums[high] });

                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }

                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }

                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] < sum)
                        {
                            low++;
                        }
                        else
                        {
                            high--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
