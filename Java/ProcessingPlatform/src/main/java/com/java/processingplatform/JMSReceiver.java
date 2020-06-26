package com.java.processingplatform;

import java.io.StringReader;
import java.time.LocalTime;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;

@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "jms/checkingQueue"),
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class JMSReceiver implements MessageListener {
    
    public JMSReceiver() {
    }
    
    @Override
    public void onMessage(Message message) {
        try {
            System.out.println("Received @" + LocalTime.now());
            
            String checkingMessage = message.getBody(String.class);
            JAXBContext jaxbContext = JAXBContext.newInstance(FileToCheck.class);
            Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
            StringReader reader = new StringReader(checkingMessage);
            FileToCheck fileInfo = (FileToCheck) unmarshaller.unmarshal(reader);
            
            // A partir d'ici, fileInfo peut être utilisé comme voulu, par exemple passé à un orchestrator
            // Orchestrator orchestrator = new Orchestrator(fileInfo);
            
            System.out.println("Processed @" + LocalTime.now() + " : [filename: " + fileInfo.getFileName() + " ; file: " + fileInfo.getFile() + " ; key: " + fileInfo.getKey() + "]");
            System.out.println(checkingMessage);
            
        } catch (JMSException | JAXBException ex) {
            Logger.getLogger(JMSReceiver.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
