package com.java.receptionplatform;

import javax.ejb.Stateless;
import javax.jms.QueueConnectionFactory;
import javax.naming.InitialContext;

@Stateless
public class JMSSender {
    
    public InitialContext ctx;
    public QueueConnectionFactory QCF;
    
    public void sendMessage(String fileName, String file, String key) {
        System.out.println("filename: " + fileName + "\nfile: " + file + "\nkey: " + key);
    }
    
}
