import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import './TaskCreator.scss'
import { useEffect } from 'react'
import axios from 'axios'

interface PortalFormProps {
  onClose: () => void;
}

interface SingleUserProps {
    id:number
    nom:string 
    photo:string
    prenom:string
}

const TaskCreator: React.FC<PortalFormProps> = ({ onClose }) => {
  const [formData, setFormData] = useState({
    libelle: 'Une nouvelle tâche',
    attribution: '',
    status: '0',
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
        const postData = {
            Id: 0,
            UserID: formData.attribution,
            Libelle: formData.libelle,
            Status: formData.status
          };
        const response = await axios.post('http://localhost:5178/api/v1/tasks', postData);
  
        console.log('Response:', response.data);
      } catch (error) {
        console.error('Error:', error);
      }
    console.log('Form submitted with data:', formData);
    onClose();
  };

  const handleCancel = () => {
    onClose();
  };

  const [data, setData] = useState<SingleUserProps[]>([]);
    
  useEffect(() => {
       axios.get("http://localhost:5178/api/v1/users")
      .then((response) => {
          setData(response.data.data);
          setFormData((prevFormData) => ({
            ...prevFormData,
            attribution: response.data.data[0].id ,
          }));
      })
      .catch(() => {
          console.log("nope");
      })

  }, []);

  return ReactDOM.createPortal(
    <div className="portal-form-overlay">
      <div className="portal-form-container">
        <form onSubmit={handleSubmit}>
          <h2>Nouvelle tâche</h2>  
          <div className="separator"></div>
          <label>
            Libellé de la tâche:
            <input
              type="text"
              name="libelle"
              value={formData.libelle}
              onChange={handleChange}
            />
          </label>
          <br />
          <label>
            Attribution:
            <select
              name="attribution"
              value={formData.attribution}
              onChange={handleChange}
            >
                {
                    data.map((item) => (
                        <React.Fragment key={item.id}>
                            <option value={item.id}>{item.nom} {item.prenom}</option>
                        </React.Fragment>
                        ))
                }
            </select>
          </label>
          <br />
          <label>
            Status:
            <select
              name="status"
              value={formData.status}
              onChange={handleChange}
            >
              <option value="0">En cours</option>
              <option value="1">Bloquée</option>
              <option value="2">Finie</option>
              {/* Add more options as needed */}
            </select>
          </label>
          <br />
          <div className="separator"></div>
          <div className="button-container">
            <button type="button" onClick={handleCancel}>Annuler</button>
            <button type="submit">Ajouter</button>
        </div>
        </form>
      </div>
    </div>,
    document.body
  );
};

export default TaskCreator;
