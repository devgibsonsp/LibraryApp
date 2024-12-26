WIP
This configuration isn’t fully tested or deployed yet

Step 1: Initialize Terraform
Run the following command to initialize Terraform in the project directory:

bash
Copy code
terraform init

Step 2: Preview the Changes
Check what Terraform plans to create without actually applying it:

bash
Copy code
terraform plan \
  -var "sql_admin_username=<user>" \
  -var "sql_admin_password=<pw>" \
  -var "frontend_repo_url=<repo url>"

Step 3: Apply the Changes
If the preview looks good, apply the configuration to deploy the resources:

bash
Copy code
terraform apply \
  -var "sql_admin_username=adminuser" \
  -var "sql_admin_password=SecurePass123!" \
  -var "frontend_repo_url=<repo url>"
Terraform will output important details like:

Backend URL for API.
Frontend URL for static site.
Database connection string for backend configuration.
Remaining Work
what’s still missing:

1. Backend,
The Terraform config currently sets up the App Service but doesn’t deploy backend code.

2 Frontend,
Ensure frontend app points to backend’s API URL after deployment.

3. Testing
Verify everything works as expected in Azure.