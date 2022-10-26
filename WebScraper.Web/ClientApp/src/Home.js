import React, {useState,useEffect} from 'react';
import axios from 'axios';

const Home = () => {
    const [items, setItems] = useState([]);
   

    useEffect (() => {
        const getArticle=async()=>{
            const { data } =  await axios.get('/api/LkwdScp/scrape');
            setItems(data);
        }
        getArticle();
    },[])

    return (
        <div className='container mt-5'>
        
           { !!items.length &&<div className='row mt-3'>
                <div className='col-md-12'>
                 <div className='container'>
                    <div className='jumbotron'>
                        {items.map((item, idx) => {
                            return <tr key={idx}>
                                
                                <h5>
                                    <a href={item.link} target='_blank'>{item.title}</a>
                                </h5>
                                <h6><img src={item.imageUrl} /></h6>
                                <h6>
                                    {item.text}
                                </h6>
                            </tr>
                        })}
                    </div>
                    </div>
                    </div>
            </div>}
        </div>
    )
}

export default Home;