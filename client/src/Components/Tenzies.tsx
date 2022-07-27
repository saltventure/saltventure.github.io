import React, { useState, useEffect } from 'react'
import '../Styles/Tenzi.css';
import Dice from './Dice';

import { nanoid } from "nanoid"
import Confetti from "react-confetti"
import { deserialize } from 'v8';



interface Props {
  user: {
      id: number | undefined,
      email: string | undefined,
      username: string | undefined,
      balance: number | undefined,
      token: string | undefined,
  },
  updateUser: (user: User) => void;

}
interface User {
  id: number | undefined,
  email: string | undefined,
  username: string | undefined,
  balance: number | undefined,
  token: string | undefined,
}

const Tenzies = ({ user, updateUser }: Props)=> {
  const [disable, setDisable] = useState(false);
  const [isWin, setIsWIn] = useState(false);
  const [reward, setReward] = useState(50);
  const [holding, setHolding] = useState("0000000000");
  const [counter, setCounter] = useState(60);
  useEffect(() => {
    counter > 0 && setTimeout(() => setCounter(counter - 1), 1000);
  }, [counter]);
  const generateNewDie = (value,isHeld) => {
    return {
      value: value,
      isHeld: isHeld,
      id: nanoid()
    }
  }
  const allNewDice = async () => {
    const requestSettings = {
      method: 'GET',
      headers: {
          'Authorization': "Bearer " + user.token,
          "Content-Type": "application/json"
      }
  };
    try {
        const response = await fetch("https://saltventure.azurewebsites.net/api/tenzies", requestSettings)
        if (!response.ok) {
            throw new Error(JSON.stringify(await response.json()));
        }
        const deserializedJSON = await response.json();  
        const newDice = []
        for (let i = 0; i < 10; i++) {
          newDice.push(generateNewDie(deserializedJSON.grid[i],deserializedJSON.holding[i] == '1'))
        }
      setDice(newDice);
      setReward(50 - deserializedJSON.round);
      setHolding(deserializedJSON.holding);
    }
    catch (err) {
    }
   
  }
  const [dice, setDice] = useState([])
  const [tenzies, setTenzies] = useState(false)

  useEffect(() => {
    allNewDice();
  },[])
  useEffect(() => {
    if(dice.length == 0) return;
    const allHeld = dice.every(die => die.isHeld)
    const firstValue = dice[0].value
    const allSameValue = dice.every(die => die.value === firstValue)
    if (allHeld && allSameValue) {
      // WON
      setTenzies(true);
      getReward();
      return;
    }
    setHolding(dice.map((die) => {
      return die.isHeld ? '1' : '0';
    }).join(""))
  }, [dice])

  const pickPositions = async () => {
    const requestSettings = {
      method: 'POST',
      headers: {
          'Authorization': "Bearer " + user.token,
          "Content-Type": "application/json"
      }
  };
    try {
        const response = await fetch("https://saltventure.azurewebsites.net/api/tenzies/pick/" + holding, requestSettings)
        if (!response.ok) {
            throw new Error(JSON.stringify(await response.json()));
        }
        const deserializedJSON = await response.json();  
        const newDice = []
        for (let i = 0; i < 10; i++) {
          newDice.push(generateNewDie(deserializedJSON.grid[i],deserializedJSON.holding[i] == '1'))
        }
      setDice(newDice);
      setReward(50 - deserializedJSON.round);
      setHolding(deserializedJSON.holding);
    }
    catch (err) {
    }
  }
  const rollDice = () => {
    if (!tenzies) {
      pickPositions();
    } else {
      setTenzies(false)
      setDice([]);
      allNewDice();
    }
  }
  useEffect(() => {
    if(reward < 0) setReward(5);
  },[reward])
  const holdDice = (id) => {
    let tempHolding = "";
    setDice(oldDice => oldDice.map(die => {
      if(die.id === id)
      {
        tempHolding += !die.isHeld == true ? '1' : '0';
        return  { ...die, isHeld: !die.isHeld } 
      }
      else {
        tempHolding += die.isHeld == true ? '1' : '0';
        return die;
      }
    }))
  }

  const diceElements = dice.map(die => (
    <Dice
      key={die.id}
      value={die.value}
      isHeld={die.isHeld}
      holdDice={() => holdDice(die.id)}
    />
  ))

  const getReward = async () => {
    if (user == undefined) return;
    const requestSettings = {
      method: 'POST',
      headers: {
          'Authorization': "Bearer " + user.token,
          "Content-Type": "application/json"
      }
  };
    try {
        const response = await fetch("https://saltventure.azurewebsites.net/api/tenzies/getreward", requestSettings)
        if (!response.ok) {
            throw new Error(JSON.stringify(await response.json()));
        }
        const deserializedJSON = await response.json();
        setIsWIn(true);
        setTimeout(() => {
          setIsWIn(false);
        },8000)  
        updateUser({ id: user.id, email: user.email, username: user.username, balance: deserializedJSON.balance, token: user.token })

    }
    catch (err) {
    }
}


  return (
    <div className='main'>
      {isWin &&   <div className="confetti-wrapper"> <Confetti className='confetti-disappear' /> </div>}

   
      
      <h1 className="title">&lt;/ Tenzies &gt;</h1>
      <p className="instructions">Roll until all dice are the same.
        Click each die to freeze it at its current value between rolls.
        </p>
        <p className='tenzies-payout'>
        Payout: <span>{reward}</span></p>
      <div className="dice-container">
        {diceElements}
      </div>
      <button
        className="roll-dice"
        onClick={() => {setDisable(false); rollDice();}}
      >
        {tenzies ? "New Game" : "Roll"}
      </button>
    </div>
  )
}
export default Tenzies


