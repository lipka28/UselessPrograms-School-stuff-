#include <iostream>
#include <omp.h>
#include <cmath>
#include <stdlib.h>
#include <time.h>

using namespace std;

double countPiPart (int at, int from)
{
    double result = (1.0 / from) * (4.0/(1.0+pow((at + 0.5)/from,2.0)));
    return result;
}

int main()
{
    time_t seconds;
    time_t sec;
    const int maxCores = omp_get_max_threads();
    int from = 0;
    int cores = 0;
    double pi = 0.0;
    //double *resultPool;

    cout << "* Wlcome to the Pi counting software 3000 *" << endl;
    while(from <= 0){
    cout << endl;
    cout << "Please select valid accuracy (recommendation 1000+): ";
    cin >> from;
    }

    while(cores <= 0){
    cout << endl;
    cout << "Please select valid number of cores (from 1 to " << maxCores << " ): ";
    cin >> cores;
    if(cores > maxCores)cores = 0;
    }
    cout << endl;

    seconds = time(NULL);

    #pragma omp parallel num_threads(cores)
    {

    #pragma omp for schedule(static) reduction(+: pi)
        for(auto i = 0; i < from; i++)
        {
            pi += countPiPart(i,from);
        }

    }
    sec = time(NULL);
    int timeSpent = sec - seconds;

    printf("\n Result: \n");
    printf("%0.50lf\n",pi);
    cout << "elapsed time: " << timeSpent << " s"<< endl;


    return 0;
}
