package com.java.processingplatform;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class FileToCheck implements Serializable{
    
    @XmlElement
    private String fileName;
    @XmlElement
    private String file;
    @XmlElement
    private String key;

    public FileToCheck() {
        
    }
    
    public FileToCheck(String fileName, String file, String key) {
        this.fileName = fileName;
        this.file = file;
        this.key = key;
    }

    public String getFileName() {
        return fileName;
    }

    public void setFileName(String fileName) {
        this.fileName = fileName;
    }

    public String getFile() {
        return file;
    }

    public void setFile(String file) {
        this.file = file;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }
    
    @Override
    public String toString() {
       return "FileToCheck[FileName=" + fileName + " File=" + file + " Key=" + key + "]";
    } 
    
}
