
import React, {  useState } from 'react';



const Generate = () => {
   
    const [amount,setAmount]=useState();
    

     

    const onClick=async()=>{
     
       window.location = `/api/people/generatecsv?amount=${amount}`;
    
    }

    return <>
    <div className="d-flex w-100 justify-content-center align-self-center">
        <div className="row">
            <input type="text" className="form-control-lg" placeholder="Amount" value={amount} onChange={(e)=>setAmount(e.target.value)}/>
        </div>
        <div class="row">
            <div className="col-md-4">
                <button onClick={onClick} className="btn btn-primary btn-lg">Generate</button>
            </div>
        </div>
    </div>
    </>
}

export default Generate;