import axios from 'axios';
import React, { useRef } from 'react';
import { useHistory } from 'react-router-dom';


const FileUpload = () => {
    const history=useHistory();
    const toBase64 = file => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
    

    const fileInputRef = useRef(null);

    const onButtonClick = async () => {
        const file = fileInputRef.current.files[0];
        const base64 = await toBase64(file);
        const name = file.name;
        await axios.post('/api/People/upload', { base64Image: base64, name });
        history.push('/');
      
     
    }

    return (
        <div className='container mt-5'>
            <div className='row'>
                <div className='col-md-12'>
                    <input ref={fileInputRef} type='file' className='form-control' />
                </div>
                <div className='col-md-12'>
                    <button className='btn btn-outline-success' onClick={onButtonClick}>Upload</button>
                </div>
            </div>
        </div>

    )
}

export default FileUpload;