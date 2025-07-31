import { Button } from "./ui/button";
import { Input } from "@/components/ui/input"
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import { useState } from "react";

export function EnterUsernameForm() {
    const [username, setUsername] = useState(''); 

    function StartChatting()  {
      console.log(username, setUsername)
    // if (username.trim()) { 
    //   //? TODO: NAVIGATE TO THE CHAT PAGE, SEND USERNAME TO THE BACKEND
      
    // } else {
    //   //? TODO: MAKE ERROR HANDLING
    // }
  };

  return (
    <Card className="w-full max-w-md">
      <CardHeader className="flex flex-col items-center text-center">
        <CardTitle className="text-3xl font-semibold">
          Enter your Username
        </CardTitle>
      </CardHeader>
      
        <CardContent>
          <div className="flex flex-col gap-4 mt-4">
            <Input
              type="text"
              placeholder="Username"
              className="w-full"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
            <Button type="submit" variant="outline" className="w-full" onClick={StartChatting} >
              Start chatting
            </Button>
          </div>
        </CardContent>
    </Card>

  )
}