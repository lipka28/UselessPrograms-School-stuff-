#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    core = new Controller(this);

    connect(core->factorial, &FacWorker::resultsReady, this, &MainWindow::handleFacResult);
    connect(core->prime, &PrimeWorker::resultReady, this, &MainWindow::handlePrimeResult);
    connect(core->prime, &PrimeWorker::allResultsSent, this, &MainWindow::handlePrimeFinished);

    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    setFacState(Aborted);
    setPrimeState(Aborted);
    delete ui;
}

void MainWindow::handleFacResult(unsigned long long result)
{
    ui->te_facOutput->clear();
    setFacState(Idle);
    ui->l_facStatus->setText(tr("Status: Idle"));
    ui->te_facOutput->append(QString::number(result));
    ui->pb_facStart->setDisabled(false);
}

void MainWindow::handlePrimeResult(unsigned int result)
{
    ui->te_primeOutput->append(QString::number(result));
}

void MainWindow::handlePrimeFinished()
{
    setPrimeState(Idle);
    ui->pb_primeStart->setDisabled(false);
    ui->l_primeStatus->setText(tr("Status: Idle"));
}

void MainWindow::on_pb_facStart_clicked()
{
    int num = ui->le_facInput->text().toInt();

    if(num < 0)QMessageBox::warning(this,tr("Negative number"),tr("Be more positive!!"));
    else{
    setFacState(Working);
    ui->l_facStatus->setText(tr("Status: Working"));
    ui->pb_facStart->setDisabled(true);
    core->startFac(num);
    }
}

void MainWindow::on_pb_primeStart_clicked()
{
    ui->te_primeOutput->clear();
    unsigned int from = ui->le_primeInFrom->text().toUInt();
    unsigned int to = ui->le_primeInTo->text().toUInt();
    if(ui->le_primeInFrom->text().toInt() < 0 || ui->le_primeInFrom->text().toInt() < 0)QMessageBox::warning(this,tr("Negative number/s"),tr("Be more positive!!"));
    else if(from > to)QMessageBox::warning(this,tr("Ouch!"),tr("Sorry! Can't count backwards"));
    else{
    setPrimeState(Working);
    ui->pb_primeStart->setDisabled(true);
    core->startPrime(from,to);
    ui->l_primeStatus->setText(tr("Status: Working"));
    }
}

void MainWindow::on_pb_primePausRes_clicked()
{
    switch (getPrimeState()) {
    case Working:
        setPrimeState(Paused);
        ui->l_primeStatus->setText(tr("Status: Paused"));
        break;
    case Paused:
        setPrimeState(Working);
        ui->l_primeStatus->setText(tr("Status: Working"));
        break;
    default:
        break;
    }
}

void MainWindow::on_pb_primeAbort_clicked()
{
    switch (getPrimeState()) {
    case Working:
    case Paused:
        setPrimeState(Aborted);
        break;
    default:
        break;
    }
}

void MainWindow::on_pb_facPausRes_clicked()
{
    switch (getFacState()) {
    case Working:
        setFacState(Paused);
        ui->l_facStatus->setText(tr("Status: Paused"));
        break;
    case Paused:
        setFacState(Working);
        ui->l_facStatus->setText(tr("Status: Working"));
        break;
    default:
        break;
    }
}

void MainWindow::on_pb_facAbort_clicked()
{
    switch (getFacState()) {
    case Working:
    case Paused:
        setFacState(Aborted);
        break;
    default:
        break;
    }
}
