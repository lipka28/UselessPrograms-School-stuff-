#include "primeworker.h"

PrimeWorker::PrimeWorker(QObject *parent) : QObject(parent)
{

}

void PrimeWorker::findPrimes(unsigned int from, unsigned int to)
{
    for(unsigned int i = from; i <= to; i++){
        if(getPrimeState() == Aborted){
            break;
        }
        else if(getPrimeState() == Paused){
            QThread::msleep(10);
            i--;
            continue;
        }
        QThread::msleep(100);
        switch (i) {
        case 1:
            //not Prime number
            break;
        case 2:
            emit resultReady(i);
            break;
        case 3:
            emit resultReady(i);
            break;
        case 5:
            emit resultReady(i);
            break;
        case 7:
            emit resultReady(i);
            break;
        default:
            if(i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)emit resultReady(i);
            break;
        }

    }
}

void PrimeWorker::doWork(unsigned int from, unsigned int to)
{
    findPrimes(from,to);
    emit allResultsSent();
}
