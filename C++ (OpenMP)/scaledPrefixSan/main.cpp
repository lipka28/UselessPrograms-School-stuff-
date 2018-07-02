#include <iostream>
#include <stdlib.h>
#include <omp.h>
#include <cmath>

using namespace std;

void debugPrintArray(unsigned int *array,unsigned int arraySize)
{
    for(unsigned int i = 0; i < arraySize; i++)
    {
        cout << " " << array[i];
    }
    cout << endl;
}

int main()
{
    unsigned int arraySize = 0, coreCount = 0;
    unsigned int maxCoreCount = omp_get_max_threads();
    unsigned int *entryArray;                // X[n]
    unsigned int *threadSubArray;            // Si[q]
    unsigned int *threadResults;             // Z[p]
    unsigned int q = 0;
    unsigned int result = 0;

    while(arraySize <= 0){
        cout << "Please insert array size (1 - N): ";
        cin >> arraySize;
        cout << endl;
    }

    while(coreCount <= 0){
        cout << "Please insert thread count (1 - " << maxCoreCount << "): ";
        cin >> coreCount;
        if(coreCount > maxCoreCount )coreCount = 0;
        cout << endl;
    }

    q = (arraySize/coreCount) + 1;
    //cout << endl << q <<endl;

    entryArray = new unsigned int[arraySize+q];
    threadSubArray = new unsigned int[q];
    threadResults = new unsigned int[coreCount];



    for(unsigned int i = 0; i < arraySize; i++)
    {
        entryArray[i] = i + 1;
    }
    //debugPrintArray(entryArray,arraySize);

    #pragma omp parallel num_threads(coreCount) shared(entryArray, threadResults) firstprivate(threadSubArray)
    {
        #pragma omp for ordered schedule(static)
        for(unsigned int i = 0; i < coreCount; i++)
        {
            for(unsigned int j = 0; j < q; j++)
            {
                #pragma omp ordered
                {
                    threadResults[i] += entryArray[(i*q)+j];
                }
            }

                #pragma omp ordered
                {
                    debugPrintArray(threadResults,coreCount);
                }
        }

        #pragma omp for schedule(static) reduction(+: result)
        for(unsigned int i = 0; i < coreCount; i++)
        {
            result += threadResults[i];
        }

    }

    cout << endl << "result si: " <<result << endl;


    delete[] entryArray;
    delete[] threadSubArray;
    delete[] threadResults;

    return 0;
}
