interface FormFieldProps {
    label: string;
    error?: string;
    children: React.ReactNode;
}

export default function FormField({ label, error, children }: FormFieldProps) {
    return (
        <div style={{ marginBottom: "1rem" }}>
            <label style={{ display: "block", fontWeight: "bold" }}>{label}</label>
            {children}
            {error && <span style={{ color: "red" }}>{error}</span>}
        </div>
    );
}
