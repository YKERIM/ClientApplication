package com.java.receptionplatform;

import java.io.StringWriter;
import java.time.LocalTime;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.Queue;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

@Stateless
public class JMSSender {
    
    @Inject
    private JMSContext context;
    
    @Resource(lookup = "jms/checkingQueue")
    private Queue checkingQueue;
    
    public void sendMessage(FileToCheck file) {
        JAXBContext jaxbContext;
        
        try {
            jaxbContext = JAXBContext.newInstance(FileToCheck.class);
            Marshaller jaxbMarshaller = jaxbContext.createMarshaller();
            StringWriter writer = new StringWriter();
            
            jaxbMarshaller.marshal(file, writer);
            String xmlMsg = writer.toString();
            
            context.createProducer().send(checkingQueue, xmlMsg);
            System.out.println("Sent @" + LocalTime.now() + " : [filename: " + file.getFileName() + " ; file: " + file.getFile() + " ; key: " + file.getKey() + "]");
            System.out.print(xmlMsg);
        } catch (JAXBException ex) {
            Logger.getLogger(JMSSender.class.getName()).log(Level.SEVERE, null, ex);
        }
        
//        Gardé au cas où, mais n'utilise pas les fonctionnalités d'EJB et est donc moins performant
//        try {
//            InitialContext ctx = new InitialContext();  
//            QueueConnectionFactory f = (QueueConnectionFactory) ctx.lookup("jms/checkingQueueConnectionFactory");  
//            QueueConnection con = f.createQueueConnection();  
//            con.start();  
//            QueueSession ses = con.createQueueSession(false, Session.AUTO_ACKNOWLEDGE);  
//            Queue t = (Queue)ctx.lookup("jms/checkingQueue");
//            QueueSender sender = ses.createSender(t);
//            try {
//                jaxbContext = JAXBContext.newInstance(FileToCheck.class);
//                Marshaller jaxbMarshaller = jaxbContext.createMarshaller();
//                StringWriter writer = new StringWriter();
//
//                jaxbMarshaller.marshal(file, writer);
//                String xmlMsg = writer.toString();
//                TextMessage msg = ses.createTextMessage(xmlMsg);
//                
//                sender.send(msg);  
//                System.out.println("Message successfully sent.");  
//                
//            } catch (JAXBException ex) {
//                Logger.getLogger(JMSSender.class.getName()).log(Level.SEVERE, null, ex);
//            }
//            
//            con.close();  
//        } catch (JMSException | NamingException e) {
//            Logger.getLogger(JMSSender.class.getName()).log(Level.SEVERE, null, e);
//        }
    }
    
}
