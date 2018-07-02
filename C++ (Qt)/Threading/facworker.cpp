#include "facworker.h"

FacWorker::FacWorker(QObject *parent) : QObject(parent)
{

}

unsigned long long FacWorker::countFac(int num)
{
    if(num == 0)return 1;
    else{
        unsigned long long result = 1;
        for(int i = 1; i <= num; i++)
        {
            if(getFacState() == Aborted){
                return 0;
            }
            else if(getFacState() == Paused){
                QThread::msleep(10);
                i--;
                continue;
            }
            QThread::msleep(250);
            result = result*i;

        }
        return result;
    }

}

void FacWorker::doWrok(int target)
{
    unsigned long long result = countFac(target);
    emit resultsReady(result);

}
