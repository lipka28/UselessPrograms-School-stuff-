#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <iostream>


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    myPi = new Pi(this);
    timer = new QTimer(this);
    checked = false;
    QObject::connect(timer,&QTimer::timeout,myPi,&Pi::evaluatePi);
    ui->actionStart_timer->setChecked(checked);

}

MainWindow::~MainWindow()
{
    delete timer;
    delete myPi;
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    ui->Output->clear();
    ui->Output->setText(myPi->toQString());
}


void MainWindow::on_actionStart_timer_triggered()
{

    if(ui->actionStart_timer->isChecked())timer->start(0);
    else timer->stop();

}

