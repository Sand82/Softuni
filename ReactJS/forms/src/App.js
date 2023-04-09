import "./App.css";
import {useEffect, useRef, useState} from 'react';

function App() {
  // const [username, setUsername] = useState('');
  // const [age, setAge] = useState('');
  // const [password, setPassword] = useState('');
  // const [bio, setBio] = useState('');
  // const [userType, setUserType] = useState('individual');
  // const [gender, setGender] = useState('');
  // const [tac, setTac] = useState(false);
  const infoRef = useRef();
  const [values, setValues] = useState({
    username: '',
    age: '',
    password: '',
    bio: '',
    gender: 'm',
    userType: 'individual',
    tac: false,
    egn: '',
    eik: '',
  });

const submitHandler = (e) => {
  e.preventDefault(); 

  // let values = Object.fromEntries(new FormData(e.target));
  
};

useEffect(()=>{
  if (values.username && values.age) {
    infoRef.current.value = `${values.username} - ${values.age}`;
  }
}, [values.username, values.age])

const changeHandler = (e) => {
  console.log(e.target);
  setValues(state => ({   
    ...state,
    [e.target.name] : [e.target.name] == 'tac' 
                    ? e.target.checked 
                    : e.target.value
  }))
};

  return (
    <div className="App">
      <header className="App-header">
        <form onSubmit={submitHandler}>
          <div>
            <label htmlFor="username">Username:</label>
            <input id="username" type="file" name="username" onChange={changeHandler} value={values.username}
            />
          </div>
          <div>
            <label htmlFor="age">Age:</label>
            <input id="age" type="number" name="age" value={values.age} onChange={changeHandler}
            />
          </div>
          <div>
            <label htmlFor="password">Password:</label>
            <input id="password" type="password" name="password" value={values.password} onChange={changeHandler}/>
          </div>
          <div>
            <label htmlFor="bio">Bio:</label>
            <textarea id="bio" cols="10" rows="4" name="bio" value={values.bio} onChange={changeHandler}/>
          </div>
          <div>
            <label htmlFor="gender">Gender:</label>
            <select name="gender" id="gender" value={values.gender} onChange={changeHandler}>
                <option value="m">Male</option>
                <option value="f">Female</option>
            </select>
          </div>          
          <div>
            <label htmlFor="individual-user-type">Individual:</label>
            <input type="radio" id="individual-user-type" name="userType" value="individual" onChange={changeHandler} checked={values.userType == "individual"}/>
            <label htmlFor="corporate-user-type">Corporate:</label>
            <input type="radio" id="corporate-user-type" name="userType" value="corporate"onChange={changeHandler} checked={values.userType == "corporate"}/>
          </div>
          <div>
            <lable htmlFor="identifire">{values.userType == 'individual' ? 'EGN' : 'EIK'}</lable>
            {values.userType == 'individual'
                ? <input type="text" id="Identifire" name="egn" value={values.egn} onChange={changeHandler}/>
                : <input type="text" id="Identifire" name="eik" value={values.eik} onChange={changeHandler}/>
            }
          </div>
          <div>
            <label htmlFor="tac">Terms and Conditions:</label>
            <input type="checkbox" id="tac" name="tac" checked={values.tac} onChange={changeHandler}/>
          </div>
          <div>
            <input type="submit" value="Register" disabled={!values.tac}/>
            {/* <button type="submit">Login</button> */}
          </div>
          <div>
            <label htmlFor="uncontrolled-input">Uncontrolled Input:</label>
            <textarea name="uncontrolled" id="uncontrolled-input" ref={infoRef}/>
          </div>          
        </form>
      </header>
    </div>
  );
}

export default App;
