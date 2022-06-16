import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';


const Home = () => {
    const history=useHistory();
  
    const [people, setPeople]=useState([]);

    useEffect(() => {
 const getPeople=async()=> {
    const { data } = await axios.get('/api/People/getpeople');
    setPeople(data);

}
getPeople();
      
    }, []);
    const deleteAll=async()=>{
        await axios.post('/api/People/deleteallpeople');
       
        setPeople([]);
    }


    return <><div className="container">
        <div className="row">
            <div className="col-md-6 offset-md-3 mt-5">
                <button onClick={deleteAll} className="btn btn-danger btn-lg btn-block">Delete All</button>
            </div>
        </div>
        <table className="table table-hover table-striped table-bordered mt-5">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Age</th>
                    <th>Address</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
         
{people &&people.map((p, idx) => {
                            return <tr key={idx}>
                                <td>{p.id}</td>
                    <td>{p.firstName}</td>
                    <td>{p.lastName}</td>
                    <td>{p.age}</td>
                    <td>{p.adress}</td>
                    <td>{p.email}</td>
                            </tr>
                        })}
            </tbody>
        </table>
        </div>
        </>
}

export default Home;