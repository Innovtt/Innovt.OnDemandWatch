# Innovt.OnDemandWatch
AWS implementation for scheduler on-demand services

When you are implementing event-driven architecture using AWS, including Lambda, DynamoDb 
and Kinesis you have to choose beteween on-demand, scale or fixed values of read and write for example.

The ideia of this project is to provide a Scheduler to decrease the number of reads and writes in Dynamo 
and watch Dynamo when configured with on-demand.


Service Type                              Schedulle            Anomaly Detection
1) Lambda.                                   yes                      yes
2) Dynamo DB                                 yes                      yes
3) Kinesis                                   yes                      no
4) 


TODO: Finish














