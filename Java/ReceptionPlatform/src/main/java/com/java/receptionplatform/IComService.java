package com.java.receptionplatform;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

@WebService(name = "ComEndpoint")
public interface IComService {
    
    @WebMethod(operationName = "checkFileOperation")
    @WebResult(name = "operationResult")
    String checkFile(
        @WebParam(name = "fileName") String fileName, 
        @WebParam(name = "fileContent") String file, 
        @WebParam(name = "cypherKey") String key
    );
    
}