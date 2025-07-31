import { EnterUsernameForm } from "@/components/enter-username-form";

export function EnterUsername() {
	return (
		<div className="min-h-screen p-4 flex items-center justify-center">
      <div className="w-full max-w-md">
        <EnterUsernameForm />
      </div>
    </div>
	);
}
