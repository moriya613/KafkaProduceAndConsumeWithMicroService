# KafkaProduceAndConsumeWithMicroService

1) - Prerequisite -

	Please Install:

	7Zip		https://www.7-zip.org/download.html

	JRE8		http://www.oracle.com/technetwork/java/javase/downloads/jre8-downloads-2133155.html

	zookeeper	https://zookeeper.apache.org/releases.html

	kafka		http://kafka.apache.org/downloads.html


2) - Run Kafka -

	Zookeeper Start 		C:\kafka-2.12>	zkServer

	Kafka Start				C:\kafka-2.12>	.\bin\windows\kafka-server-start.bat .\config\server.properties

	Create Topic			C:\kafka-2.12\bin\windows>	kafka-topics.bat --create --zookeeper localhost:9092 --replication-factor 1 --partitions 1 --topic LSports


3) - Run visual Studio solution attached - 
	run the solution , your browser will be opened and disply the produce and consume microservices 
  you can access tem using http rest api using Swagger ui
  
  In order to start the consumer you will need to send the time in seconds the consumer will wait for messages (in http request) 
  as a response you will get all the messages it consumed
  
  In order to produce messages , just send an http get request to the produce microservice 
  
	the Json file with all the messages to produce is already attached as embedded file so don't need to handle it
