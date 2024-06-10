using System;


class Program{
    static void Main(){
        // Say I want to make the Vendor B Light have method turn on and turn off
        VendorBLight vendorBLight = new();

        vendorBLight.TurnOnLight(true);
        vendorBLight.TurnOnLight(false);

        IVendorALight vendorBtoVendorA = new VendorAAdapter(vendorBLight);

        vendorBtoVendorA.TurnOn();
        vendorBtoVendorA.TurnOff();

    }
}


public interface IVendorALight{
    void TurnOn();
    void TurnOff();
}

public class VendorALight:IVendorALight{
    public void TurnOn(){
        Console.WriteLine("Light Vendor A Turn on");
    }
    public void TurnOff(){
        Console.WriteLine("Light Vendor A Turn off");
    }
}



public class VendorBLight{
    public void TurnOnLight(bool on){
        if(on){
            Console.WriteLine("Light Vendor B Turn on");
        }
        else{
            Console.WriteLine("Light Vendor B Turn off");
        }
    }
}

public class VendorAAdapter:IVendorALight{
    public VendorBLight vendorB = new VendorBLight();
    public VendorAAdapter(VendorBLight vendor){
        vendorB = vendor;
    }
    public void TurnOn(){
        vendorB.TurnOnLight(true);
    }
    public void TurnOff(){
        vendorB.TurnOnLight(false);
    }
}