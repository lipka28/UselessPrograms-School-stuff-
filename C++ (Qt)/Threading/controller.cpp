#include "controller.h"

Controller::Controller(QObject *parent) : QObject(parent)
{
    factorial = new FacWorker;
    prime = new PrimeWorker;

    factorial->moveToThread(&facThread);
    prime->moveToThread(&primeThread);

    connect(&primeThread, &QThread::finished, prime, &QObject::deleteLater);
    connect(&facThread, &QThread::finished, factorial, &QObject::deleteLater);
    connect(this, &Controller::startPrime, prime, &PrimeWorker::doWork);
    connect(this, &Controller::startFac, factorial, &FacWorker::doWrok);

    facThread.start();
    primeThread.start();

}

Controller::~Controller()
{
    facThread.quit();
    facThread.wait();
    primeThread.quit();
    primeThread.wait();

}
