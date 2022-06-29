using Microsoft.Extensions.Configuration;
using System.DirectoryServices;
using Base.Services.LDAP.Models;

namespace Base.Services.LDAP
{
    // Clase para Agrupar todos los métodos del Directorio Activo
    public class LdapService
    {
        private readonly IConfiguration _config;
        private string _ldapPath;
        private string _ldapDomain;
        private string _ldapUser;
        private string _ldapPassword;
        private DirectoryEntry _ldapEntry;

        // obtener los datos del directorio activo desde variables de appsettings.json
        public LdapService(IConfiguration config)
        {
            _config = config;
            _ldapPath = config["LDAP:LDAPPath"];
            _ldapDomain = config["LDAP:LDAPDomain"];
            _ldapUser = config["LDAP:LDAPUser"];
            _ldapPassword = config["LDAP:LDAPPassword"];
#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
            _ldapEntry = new DirectoryEntry(_ldapPath, _ldapUser, _ldapPassword);
#pragma warning restore CA1416 // Validar la compatibilidad de la plataforma
        }

        // Crear Un Usuario en el Directorio Activo
        /* Campos de entrada:
         * - username: nombre de usuario a crear
         * - displayName: nombre completo del usuario
         * - email: correo electrónico del usuario
         * - password: contraseña del usuario
         * - roles: roles del usuario
         * - enabled: indica si el usuario está habilitado o no
         */
        public void CreateUser(LdapUser user)
        {
            // crear un nuevo usuario en el directorio activo
            DirectoryEntry userEntry = _ldapEntry.Children.Add(user.Username, "user");
            userEntry.Properties["displayName"].Value = user.DisplayName;
            userEntry.Properties["mail"].Value = user.Email;
            userEntry.Invoke("SetPassword", user.Password);
            userEntry.Properties["userPrincipalName"].Value = user.Username + "@" + _ldapDomain;
            userEntry.Properties["sAMAccountName"].Value = user.Username;
            userEntry.Properties["userAccountControl"].Value = user.Enabled ? 0x200 : 0x2;
            // crear los roles del usuario
            foreach (string role in user.Roles)
            {
                DirectoryEntry roleEntry = GetRole(role);
                if (roleEntry != null)
                {
                    userEntry.Invoke("Add", new object[] { roleEntry.Path });
                    roleEntry.Close();
                    roleEntry.Dispose();
                }
            }

            userEntry.CommitChanges();
            userEntry.Close();
            userEntry.Dispose();
        }

        // método para Obtener un rol del Directorio Activo
        /* Campos de entrada:
         * - role: nombre del rol a obtener
         */
        public DirectoryEntry GetRole(string role)
        {
            // obtener un rol del directorio activo
            DirectoryEntry roleEntry = _ldapEntry.Children.Find(role, "group");
            return roleEntry;
        }

        // método para Obtener un usuario del Directorio Activo
        // Retorna una Exception si el usuario no existe en el directorio activo
        /* Campos de entrada:
         * - username: nombre de usuario a obtener
         */
        public DirectoryEntry GetUser(string username) =>
            _ldapEntry.Children.Find(username, "user");

        // método para Obtener una lista de usuarios del Directorio Activo
        public List<DirectoryEntry> GetUsers()
        {
            // obtener una lista de usuarios del directorio activo
            List<DirectoryEntry> users = new List<DirectoryEntry>();
            foreach (DirectoryEntry user in _ldapEntry.Children)
            {
                if (user.SchemaClassName == "user")
                {
                    users.Add(user);
                }
            }
            return users;
        }

        // método para Obtener una lista de roles del Directorio Activo
        public List<DirectoryEntry> GetRoles()
        {
            // obtener una lista de roles del directorio activo
            List<DirectoryEntry> roles = new List<DirectoryEntry>();
            foreach (DirectoryEntry role in _ldapEntry.Children)
            {
                if (role.SchemaClassName == "group")
                {
                    roles.Add(role);
                }
            }
            return roles;
        }

        // método para Actualizar un usuario en el Directorio Activo
        /* Campos de Entrada:
            * - username: nombre de usuario a actualizar
            * - user: objeto con los datos del usuario a actualizar
        */
        public void UpdateUser(string username, LdapUser user)
        {
            // actualizar un usuario en el directorio activo
            DirectoryEntry userEntry = GetUser(username);
            userEntry.Properties["displayName"].Value = user.DisplayName;
            userEntry.Properties["mail"].Value = user.Email;
            userEntry.Invoke("SetPassword", user.Password);
            userEntry.Properties["userPrincipalName"].Value = user.Username + "@" + _ldapDomain;
            userEntry.Properties["sAMAccountName"].Value = user.Username;
            userEntry.Properties["userAccountControl"].Value = user.Enabled ? 0x200 : 0x2;
            // eliminar los roles del usuario
            foreach (string role in user.Roles)
            {
                DirectoryEntry roleEntry = GetRole(role);
                if (roleEntry != null)
                {
                    userEntry.Invoke("Remove", new object[] { roleEntry.Path });
                    roleEntry.Close();
                    roleEntry.Dispose();
                }
            }
            // agregar los roles del usuario
            foreach (string role in user.Roles)
            {
                DirectoryEntry roleEntry = GetRole(role);
                if (roleEntry != null)
                {
                    userEntry.Invoke("Add", new object[] { roleEntry.Path });
                    roleEntry.Close();
                    roleEntry.Dispose();
                }
            }
            userEntry.CommitChanges();
            userEntry.Close();
            userEntry.Dispose();
        }
    }
}
