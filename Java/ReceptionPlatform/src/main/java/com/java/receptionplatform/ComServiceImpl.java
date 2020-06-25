package com.java.receptionplatform;

import javax.ejb.Stateless;
import javax.jws.WebService;

@Stateless
@WebService(
    endpointInterface = "com.java.receptionplatform.IComService",
    portName = "ComPort",
    serviceName = "ComService"
)
public class ComServiceImpl implements IComService {
    
    private JMSSender jmsSender;

    public ComServiceImpl() {
        this.jmsSender = new JMSSender();
    }

    @Override
    public String checkFile(String fileName, String file, String key) {
        if (fileName != null && !fileName.isEmpty()) {
            if (file != null && !file.isEmpty()) {
                if (key != null && !key.isEmpty()) {
                    this.jmsSender.sendMessage(fileName, file, key);
                    return "Inputs accepted";
                } else {
                    return "Invalid key";
                }
            } else {
                return "Invalid file content";
            }
        } else {
            return "Invalid file name";
        }
    }
    
}
