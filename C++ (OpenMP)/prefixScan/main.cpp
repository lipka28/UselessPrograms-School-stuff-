#include <iostream>
#include <stdlib.h>
#include <cmath>
#include <omp.h>

using namespace std;

void debugPrintArray(int *array,int arraySize)
{
    for(int i = 0; i < arraySize; i++)
    {
        cout << " " << array[i];
    }
    cout << endl;
}

int main()
{
    int arraySize = 0;
    int *array;
    int y = 0;
    int j = 0;

    while(arraySize <= 0){
    cout << "Zadejte velisokt vstupního pole: ";
    cin >> arraySize;
    }
    cout << endl;

    array = new int[arraySize];

    for (int i = 0; i < arraySize;i++)
    {
       array[i] = i+1;
    }

    #pragma omp parallel firstprivate(y) shared(array) num_threads(arraySize)
    {
        #pragma omp for
        for(int i = 0; i < arraySize; i++)
        {
            y = array[i];
        }
    }

    //for(int j = 0; j < 1/*logn*/; j++)
    //{
    #pragma omp parallel shared(array) num_threads(arraySize)
    {
        #pragma omp for ordered
        for(int i = (int)pow(2,j); i <= arraySize;i++)
        {
            #pragma omp ordered
            {
            y += array[i - (int)pow(2,j)];
            }

        }
        #pragma omp for
        for(int i = (int)pow(2,j); i < arraySize;i++)
        {
            array[i] = y;
        }

    }

    //}

    cout << "Výsledek je: " << array[arraySize-1] << endl;



    delete array;

    return 0;
}
